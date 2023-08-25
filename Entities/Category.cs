using Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
        public Category()
        {
            Articles = new HashSet<Article>();
        }
    }
}
