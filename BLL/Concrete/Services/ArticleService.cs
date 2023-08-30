using AutoMapper;
using BLL.Abstract.IServices;
using DAL.UnitOfWorks;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.Articles;
using Models.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CreateArticleAsync(ArticleAddDTo articleAddDTo)
        {
            var userId = Guid.Parse("56C089E4-D413-42C4-AFF3-3A5E84336DFC");

            var article = new Article
            {
                Title = articleAddDTo.Title,
                Content = articleAddDTo.Content,
                CategoryId = articleAddDTo.CategoryId,
                CreatedBy = userId.ToString()
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

    }
}
