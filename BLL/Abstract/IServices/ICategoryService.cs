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
    }
}
