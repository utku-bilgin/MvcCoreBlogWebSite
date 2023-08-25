﻿using Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Image : BaseEntity
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<Article> Articles { get; set; }
        public Image()
        {
            Articles = new HashSet<Article>();
        }
    }
}
