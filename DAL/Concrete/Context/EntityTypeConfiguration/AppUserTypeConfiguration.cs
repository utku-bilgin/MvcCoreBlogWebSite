using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Context.EntityTypeConfiguration
{
    public class AppUserTypeConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //// Primary key
            //builder.HasKey(u => u.Id);

            //// Indexes for "normalized" username and email, to allow efficient lookups
            //builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            //builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            //// Maps to the AspNetUsers table
            //builder.ToTable("AspNetUsers");

            //// A concurrency token for use with the optimistic concurrency checking
            //builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            //// Limit the size of columns to use efficient database types
            //builder.Property(u => u.UserName).HasMaxLength(256);
            //builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            //builder.Property(u => u.Email).HasMaxLength(256);
            //builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            //// The relationships between User and other entity types
            //// Note that these relationships are configured with no navigation properties

            //// Each User can have many UserClaims
            //builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            //// Each User can have many UserLogins
            //builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            //// Each User can have many UserTokens
            //builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            //// Each User can have many entries in the UserRole join table
            //builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();


            var superadmin = new AppUser
            {
                Id = Guid.Parse("9A205F8B-713E-458B-8C16-39660DBC392F"),
                UserName = "superadmin@gmail.com",
                NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                Email = "superadmin@gmail.com",
                NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                PhoneNumber = "+905439992222",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = "1",
                FirtsName = "Utku",
                LastName = "Bilgin"

            };
            superadmin.PasswordHash = CreatePasswordHash(superadmin, "1234As.");

            var admin = new AppUser
            {
                Id = Guid.Parse("8C2DE2A2-9825-4626-BA41-43D0661F5E62"),
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "+905439998877",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = "1",
                FirtsName = "Utku22",
                LastName = "Bilgin22"

            };
            admin.PasswordHash = CreatePasswordHash(admin, "1234As.");

            var user = new AppUser
            {
                Id = Guid.Parse("56C089E4-D413-42C4-AFF3-3A5E84336DFC"),
                UserName = "user@gmail.com",
                NormalizedUserName = "USER@GMAIL.COM",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                PhoneNumber = "+905439995544",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = "1",
                FirtsName = "Utku34",
                LastName = "Bilgin34"

            };
            user.PasswordHash = CreatePasswordHash(user, "1234As.");



            builder.HasData(superadmin, admin, user);
        }


        /// <summary>
        /// Kullanıcılara şifresini Hash olarak oluşturuyoruz
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }


    }
}
