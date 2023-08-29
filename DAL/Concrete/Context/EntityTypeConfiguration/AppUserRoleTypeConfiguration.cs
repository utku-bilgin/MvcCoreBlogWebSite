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
    public class AppUserRoleTypeConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            //// Primary key
            //builder.HasKey(r => new { r.UserId, r.RoleId });

            //// Maps to the AspNetUserRoles table
            //builder.ToTable("AspNetUserRoles");

            builder.HasData(
                new AppUserRole { UserId = Guid.Parse("9A205F8B-713E-458B-8C16-39660DBC392F"), RoleId = Guid.Parse("A776FC3D-7B19-4D1F-9373-9A015200FD49") },
                new AppUserRole { UserId= Guid.Parse("8C2DE2A2-9825-4626-BA41-43D0661F5E62"), RoleId= Guid.Parse("F90D81DE-EE52-4B44-B9AC-664578FA322D") },
                new AppUserRole { UserId= Guid.Parse("56C089E4-D413-42C4-AFF3-3A5E84336DFC"), RoleId= Guid.Parse("76FD5768-66E5-4F06-B62B-8DB720A2B5D8") });
        }
    }
}
