using Entities;
using Models.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract.IServices
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTo>> GetAllCategoriesNonDeleted();
        Task CreateCategoryAsync(CategoryAddDTo categoryAddDTo);
        Task<Category> GetCategoryByGuid(Guid id);

        Task<string> UpdateCategoryAsync(CategoryUpdateDTo categoryUpdateDTo);
        Task<string> SafeDeleteCategoryAsync(Guid categoryId);
    }
}
