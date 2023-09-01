using AutoMapper;
using BLL.Abstract.IServices;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Articles;
using NToastNotify;
using Web.NToastNotifyResultMessages;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;

        public ArticleController(IArticleService articleService, UserManager<AppUser> userManager, ICategoryService categoryService, IMapper mapper, IToastNotification toast)
        {
            _articleService = articleService;
            _userManager = userManager;
            _categoryService = categoryService;
            _mapper = mapper;
            _toast = toast;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticleWithCategoryNonDeletedAsync();
            //var userIds = articles.Select(article => Guid.Parse(article.CreatedBy)).ToList();
            //var users = await _userManager.Users.Where(user => userIds.Contains(user.Id)).ToListAsync();

            ////Article'ların CreatedBy bilgisine UserName ı eşitle
            //foreach (var article in articles)
            //{
            //    var user = users.FirstOrDefault(u => u.Id.ToString() == article.CreatedBy);
            //    if (user != null)
            //    {
            //        article.CreatedBy = user.UserName;
            //    }
            //}
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDTo { Categories = categories});
        }





        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDTo articleAddDTo)
        {

            if (articleAddDTo.Categories == null && articleAddDTo.Title != null && articleAddDTo.Content != null && articleAddDTo.CategoryId != null)
            {
                await _articleService.CreateArticleAsync(articleAddDTo);
                _toast.AddSuccessToastMessage(Messages.Article.Add(articleAddDTo.Title), new ToastrOptions { Title = "Başarılı"});
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                // Veriler geçerli değilse sayfayı tekrar göster
                var categories = await _categoryService.GetAllCategoriesNonDeleted();
                articleAddDTo.Categories = categories; // Kategorileri yeniden doldur

                return View(articleAddDTo);
            }
        }



        [HttpGet]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await _articleService.GetArticleWithCategoryNonDeletedAsync(articleId);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            var articleUpdateDTo = _mapper.Map<ArticleUpdateDTo>(article);
            articleUpdateDTo.Categories = categories;

            return View(articleUpdateDTo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateDTo articleUpdateDTo)
        {
            var title = await _articleService.UpdateArticleAsync(articleUpdateDTo); //burada güncellendiyse güncel halini, güncellenmediyse eski halini alıyoruz
            _toast.AddSuccessToastMessage(Messages.Article.Update(title), new ToastrOptions() { Title = "Başarılı" });
            await _articleService.UpdateArticleAsync(articleUpdateDTo);
            
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            articleUpdateDTo.Categories = categories;
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }

        public async Task<IActionResult> Delete(Guid articleId)
        {
            await _articleService.SafeDeleteArticleAsync(articleId);
            var title = await _articleService.SafeDeleteArticleAsync(articleId);
            _toast.AddSuccessToastMessage(Messages.Article.Delete(title), new ToastrOptions() { Title = "Başarılı" });
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}
