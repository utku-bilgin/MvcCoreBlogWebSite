using Microsoft.AspNetCore.Http;
using Models.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Articles
{
    public class ArticleAddDTo
    {
        [Required(ErrorMessage = "Başlık alanı boş bırakmayınız")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Başlık min 3 max 50 karakterden oluşmalıdır")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik alanı boş bırakmayınız")]
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public IList<CategoryDTo> Categories { get; set; }

        [Required(ErrorMessage = "Resim alanı boş bırakmayınız")]
        public IFormFile Photo { get; set; }
    }
}
