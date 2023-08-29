using DAL.Concrete.Context.EntityTypeConfiguration;
using Entities;
using Microsoft.AspNetCore.Identity;
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
    public class AppIdentityDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new AppRoleClaimTypeConfiguration())
                        .ApplyConfiguration(new AppRoleTypeConfiguration())
                        .ApplyConfiguration(new AppUserClaimTypeConfiguration())
                        .ApplyConfiguration(new AppUserLoginTypeConfiguration())
                        .ApplyConfiguration(new AppUserRoleTypeConfiguration())
                        .ApplyConfiguration(new AppUserTokenTypeConfiguration())
                        .ApplyConfiguration(new AppUserTypeConfiguration());

            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}

