using Entities;
using Microsoft.AspNetCore.Http;
using Models.DTOs.Categories;

namespace Models.DTOs.Articles
{
    public class ArticleDetailDTo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public IList<CategoryDTo> Categories { get; set; }

        public Image Image { get; set; }
    }
}
