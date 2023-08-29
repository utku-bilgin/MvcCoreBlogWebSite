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
            //// Primary key
            //builder.HasKey(r => r.Id);

            //// Index for "normalized" role name to allow efficient lookups
            //builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            //// Maps to the AspNetRoles table
            //builder.ToTable("AspNetRoles");

            //// A concurrency token for use with the optimistic concurrency checking
            //builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            //// Limit the size of columns to use efficient database types
            //builder.Property(u => u.Name).HasMaxLength(256);
            //builder.Property(u => u.NormalizedName).HasMaxLength(256);

            //// The relationships between Role and other entity types
            //// Note that these relationships are configured with no navigation properties

            //// Each Role can have many entries in the UserRole join table
            //builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            //// Each Role can have many associated RoleClaims
            //builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

            builder.HasData(
                new AppRole { Id = Guid.Parse("A776FC3D-7B19-4D1F-9373-9A015200FD49"), Name = "Superadmin", NormalizedName = "SUPERADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
                new AppRole { Id= Guid.Parse("F90D81DE-EE52-4B44-B9AC-664578FA322D"), Name="Admin", NormalizedName="ADMIN", ConcurrencyStamp= Guid.NewGuid().ToString() },
                new AppRole { Id= Guid.Parse("76FD5768-66E5-4F06-B62B-8DB720A2B5D8"), Name="User", NormalizedName="USER", ConcurrencyStamp= Guid.NewGuid().ToString() }
            );
        }
    }
}
