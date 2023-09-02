using AutoMapper;
using Entities;
using Models.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete.Mapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTo, Category>().ReverseMap();
            CreateMap<CategoryAddDTo, Category>().ReverseMap();
            CreateMap<CategoryUpdateDTo, Category>().ReverseMap();
        }
    }
}
