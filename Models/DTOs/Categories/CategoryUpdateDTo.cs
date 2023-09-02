using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Categories
{
    public class CategoryUpdateDTo
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Kategoriyi boş bırakmayınız")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Kategori min 3 max 50 karakterden oluşmalıdır")]
        public string Name { get; set; }
    }
}
