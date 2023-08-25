using DAL.Abstract;
using DAL.Concrete.Context;
using DAL.Concrete.Repositories.IdentityRepo;
using DAL.Concrete.Repositories.StandartRepo;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public static class EfContextDAL
    {
        //dependinse injection yapılan yer
        public static IServiceCollection AddScopedDAL(this IServiceCollection services)
        {
            services.AddDbContext<StandartContext>(option =>
            {
                string standartConnection = "server=.; Database= standart; Trusted_Connection=True";
                option.UseSqlServer(standartConnection);
            });

            services.AddDbContext<StandartContext>(option =>
            {
                string identityConnection = "server=.; Database= standart; Trusted_Connection=True";
                option.UseSqlServer(identityConnection);
            })
                    .AddDbContext<AppIdentityContext>()
                    .AddScoped<IArticleRepo, ArticleRepo>()
                    .AddScoped<ICategoryRepo, CategoryRepo>()
                    .AddScoped<IImageRepo, ImageRepo>()
                    .AddScoped<IUserRepo, UserRepo>()
                    .AddScoped<IRoleRepo, RoleRepo>();

            //services.AddIdentityCore<AppIdentityContext>(); // mustafadan eklenecek

            services.AddIdentityCore<AppRole>().AddRoles<AppRole>().AddEntityFrameworkStores<AppIdentityContext>();

            //User > ().AddRoles<AppRole>().AddEntityFrameworkStores<AppIdentityContext>();

            return services;
        }
    }
}
