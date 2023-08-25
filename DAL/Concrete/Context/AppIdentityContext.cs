using DAL.Concrete.Context.EntityTypeConfiguration;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Context
{
    public class AppIdentityContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options) { }

        public virtual DbSet<AppUserRole> UserRoles { get; set; }

        
    }
}
