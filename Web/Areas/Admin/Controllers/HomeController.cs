using BLL.Abstract.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;

        public HomeController(IArticleService articleService)
        {
            this.articleService = articleService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var article = await articleService.GetAllArticleAsync();
            return View(article);
        }
    }
}
