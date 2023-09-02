using AutoMapper;
using BLL.Abstract.IServices;
using BLL.Extensions;
using BLL.Helpers.Images;
using Core.Enums;
using DAL.UnitOfWorks;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Models.DTOs.Articles;
using System.Security.Claims;

namespace BLL.Concrete.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IImageHelper _imageHelper;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _imageHelper = imageHelper;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateArticleAsync(ArticleAddDTo articleAddDTo)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            var imageUpload = await _imageHelper.Upload(articleAddDTo.Title, articleAddDTo.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, articleAddDTo.Photo.ContentType, userEmail);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);
            

            var article = new Article(articleAddDTo.Title, articleAddDTo.Content, articleAddDTo.CategoryId, image.Id)
            {
                CreatedBy = userEmail
            };

            await _unitOfWork.GetRepository<Article>().AddAsync(article);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleDTo>> GetAllArticleWithCategoryNonDeletedAsync()
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x=>!x.IsDeleted, x=>x.Category);
            var map = _mapper.Map<List<ArticleDTo>>(articles);

            return map;
        }

        public async Task<ArticleDTo> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i => i.Image);
            var map = _mapper.Map<ArticleDTo>(article);

            return map;
        }

        public async Task<string> UpdateArticleAsync(ArticleUpdateDTo articleUpdateDTo)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDTo.Id, x => x.Category, i => i.Image);

            if(articleUpdateDTo.Photo != null)
            {
                _imageHelper.Delete(article.Image.FileName);

                var imageUpload = await _imageHelper.Upload(articleUpdateDTo.Title, articleUpdateDTo.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, articleUpdateDTo.Photo.ContentType, userEmail);
                await _unitOfWork.GetRepository<Image>().AddAsync(image);
                article.ImageId = image.Id;
;            }

            article.Title = articleUpdateDTo.Title;
            article.Content = articleUpdateDTo.Content;
            article.CategoryId = articleUpdateDTo.CategoryId;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = _user.GetLoggedInEmail();

            //_mapper.Map<ArticleUpdateDTo>(article);
            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();

            return article.Title;
        }

        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = _user.GetLoggedInEmail();

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();

            return article.Title;
        }
    }
}
