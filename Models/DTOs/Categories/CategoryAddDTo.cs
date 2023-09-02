using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Categories
{
    public class CategoryAddDTo
    {
        [Required(ErrorMessage = "Kategoriyi boş bırakmayınız")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Kategori min 3 max 50 karakterden oluşmalıdır")]
        public string Name { get; set; }
    }
}
