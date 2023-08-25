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
    public class AppRoleTypeConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole { Id=1, Name="Admin", NormalizedName="ADMIN", ConcurrencyStamp="1"},
                new AppRole { Id=2, Name="User", NormalizedName="USER", ConcurrencyStamp="2"});
        }
    }
}
