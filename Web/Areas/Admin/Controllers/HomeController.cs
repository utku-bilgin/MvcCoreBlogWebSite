﻿using BLL.Abstract.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;

        public HomeController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var article = await _articleService.GetAllArticleWithCategoryNonDeletedAsync();
            return View(article);
        }
    }
}