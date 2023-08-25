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
    public class AppUserTypeConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            

            var admin = new AppUser
            {
                Id = 1,
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "+905439998877",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = "1",
                FirtsName = "Utku",
                LastName = "Bilgin"

            };
            admin.PasswordHash = CreatePasswordHash(admin, "1234As.");

            var user = new AppUser
            {
                Id = 2,
                UserName = "user@gmail.com",
                NormalizedUserName = "USER@GMAIL.COM",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                PhoneNumber = "+905439995544",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = "1",
                FirtsName = "Utku22",
                LastName = "Bilgin22"

            };
            user.PasswordHash = CreatePasswordHash(user, "1234As.");



            builder.HasData(admin, user);
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
