using Core.BaseEntities;
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
    public class ArticleTypeConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id)
                   .UseIdentityColumn(1,1);
            builder.HasData(
                new Article
                {
                    Id = 1,
                    Title = "Asp.Net Core Deneme Makalesi 1",
                    Content = "Asp.Net Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ViewCount = 15,
                    CategoryId = 1,
                    ImageId = 1,
                    CreatedBy = "AdminTest",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Article
                {
                    Id = 2,
                    Title = "Visual Studio Deneme Makalesi 1",
                    Content = "Visual Studio Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ViewCount = 15,
                    CategoryId = 1,
                    ImageId = 1,
                    CreatedBy = "AdminTest",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                }
                );
        }
    }
}
