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
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .UseIdentityColumn(1, 1);
            builder.HasData(
                new Image
                {
                    Id = 1,
                    FileName = "images/testimage",
                    FileType = "jpg",
                    CreatedBy = "Admin test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                },
                new Image
                {
                    Id = 2,
                    FileName = "images/vstest",
                    FileType = "png",
                    CreatedBy = "Admin test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                }
                );
        }
    }
}
