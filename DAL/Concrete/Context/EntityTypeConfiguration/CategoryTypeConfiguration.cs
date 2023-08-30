using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Context.EntityTypeConfiguration
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id)
            //       .UseIdentityColumn(1, 1);
            builder.HasData(
                new Category
                {
                    Id = Guid.Parse("AEB70F85-9272-4C29-B71E-7DD2A4FDF3F9"),
                    Name = "ASP.Net Core",
                    CreatedBy = Guid.Parse("8C2DE2A2-9825-4626-BA41-43D0661F5E62").ToString(),
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                }, new Category
                {
                    Id = Guid.Parse("9BD797A0-812D-4EAD-B3A4-E549336F6E6F"),
                    Name = "Visual Studio 2022",
                    CreatedBy = Guid.Parse("8C2DE2A2-9825-4626-BA41-43D0661F5E62").ToString(),
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                }
                );
        }
    }
}
