using DAL.Concrete.Context.EntityTypeConfiguration;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Context
{
    public class StandartContext : DbContext
    {
        public StandartContext(DbContextOptions<StandartContext> options) : base(options) { }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleTypeConfiguration())
                        .ApplyConfiguration(new CategoryTypeConfiguration())
                        .ApplyConfiguration(new ImageTypeConfiguration());
        }
    }
}
