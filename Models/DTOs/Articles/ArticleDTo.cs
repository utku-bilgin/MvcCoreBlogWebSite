﻿using Entities;
using Models.DTOs.Categories;

namespace Models.DTOs.Articles
{
    public class ArticleDTo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CategoryDTo Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Image Image { get; set; }
    }
}
