using AutoMapper;
using BLL.Abstract.IServices;
using BLL.Concrete.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Articles;
using Models.DTOs.Categories;
using NToastNotify;
using Web.NToastNotifyResultMessages;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;

        public CategoryController(ICategoryService categoryService, IMapper mapper, IToastNotification toast)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDTo categoryAddDTo)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddDTo);
                _toast.AddSuccessToastMessage(Messages.Category.Add(categoryAddDTo.Name), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }

            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDTo categoryAddDTo)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddDTo);
                _toast.AddSuccessToastMessage(Messages.Category.Add(categoryAddDTo.Name), new ToastrOptions { Title = "Başarılı" });
                return Json(Messages.Category.Add(categoryAddDTo.Name));
            }
            else
            {
                _toast.AddErrorToastMessage(Messages.Category.Add(categoryAddDTo.Name), new ToastrOptions { Title = "Başarısız" });
                return Json(new { message = "Hata oluştu" });
            }
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid categoryId)
        { var category = await _categoryService.GetCategoryByGuid(categoryId);
            var map = _mapper.Map<Category, CategoryUpdateDTo>(category);

            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDTo categoryUpdateDTo)
        {
            if (ModelState.IsValid)
            {
                var name = await _categoryService.UpdateCategoryAsync(categoryUpdateDTo);
                _toast.AddSuccessToastMessage(Messages.Category.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });


                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            await _categoryService.SafeDeleteCategoryAsync(categoryId);
            var name = await _categoryService.SafeDeleteCategoryAsync(categoryId);
            _toast.AddSuccessToastMessage(Messages.Category.Delete(name), new ToastrOptions() { Title = "Başarılı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

    }
}
