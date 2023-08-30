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
    public class ImageTypeConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id)
            //       .UseIdentityColumn(1, 1);
            builder.HasData(
                new Image
                {
                    Id = Guid.Parse("659E7A9F-96E8-4B89-9A9A-6C27DE62A083"),
                    FileName = "images/testimage",
                    FileType = "jpg",
                    CreatedBy = Guid.Parse("8C2DE2A2-9825-4626-BA41-43D0661F5E62").ToString(),
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                },
                new Image
                {
                    Id = Guid.Parse("9324BE78-0522-499F-97A2-BC8B5AF88ABC"),
                    FileName = "images/vstest",
                    FileType = "png",
                    CreatedBy = Guid.Parse("8C2DE2A2-9825-4626-BA41-43D0661F5E62").ToString(),
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                }
                );
        }
    }
}
