using AutoMapper;
using Entities;
using Models.DTOs.Articles;

namespace BLL.Concrete.Mapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDTo, Article>().ReverseMap();
            CreateMap<ArticleUpdateDTo, Article>().ReverseMap();
            CreateMap<ArticleUpdateDTo, ArticleDTo>().ReverseMap();
            CreateMap<ArticleAddDTo, Article>().ReverseMap();
        }
    }
}
