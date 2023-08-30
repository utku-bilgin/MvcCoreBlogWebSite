using BLL.Abstract.IServices;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.Articles;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryService _categoryService;

        public ArticleController(IArticleService articleService, UserManager<AppUser> userManager, ICategoryService categoryService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticleWithCategoryNonDeletedAsync();

            var userIds = articles.Select(article => Guid.Parse(article.CreatedBy)).ToList();
            var users = await _userManager.Users.Where(user => userIds.Contains(user.Id)).ToListAsync();

            // Article'ların CreatedBy bilgisine UserName ı eşitle
            foreach (var article in articles)
            {
                var user = users.FirstOrDefault(u => u.Id.ToString() == article.CreatedBy);
                if (user != null)
                {
                    article.CreatedBy = user.UserName;
                }
            }
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
            await _articleService.CreateArticleAsync(articleAddDTo);
            return RedirectToAction("Index", "Article", new { Area = "Admin"});

            //var categories = await _categoryService.GetAllCategoriesNonDeleted();
            //return View(new ArticleAddDTo { Categories = categories });
        }
    }
}
