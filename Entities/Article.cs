using Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public Image Image { get; set; }
        public int ImageId { get; set; }
    }
}
