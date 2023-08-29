using DAL.Abstract;
using DAL.Concrete.Context;
using DAL.Concrete.Repositories;
using DAL.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions
{
    //public static class DataLayerExtensions
    //{
    //    public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
    //    {
    //        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    //        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

    //        //dependency injection
    //        services.AddScoped<IUnitOfWork, UnitOfWork>();
    //        return services;
    //    }
    //}

    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            // Blog veritabanı bağlantısı
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // Identity veritabanı bağlantısı
            services.AddDbContext<AppIdentityDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("IdentityConnection")));

            // IRepository ve UnitOfWork işlemleri ekleme
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }

}