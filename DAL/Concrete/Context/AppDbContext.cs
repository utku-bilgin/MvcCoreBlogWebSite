using DAL.Concrete.Context.EntityTypeConfiguration;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new ArticleTypeConfiguration())
                        .ApplyConfiguration(new CategoryTypeConfiguration())
                        .ApplyConfiguration(new ImageTypeConfiguration());

            // Yukarıdaki yazımda ApplyConfiguration() ile her seferinde tanımlamaktansa aşağıdaki gibi yazabiliriz. Her tanımlanan TypeConfiguration otomatik olarak tanımlanmış olucak.
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
