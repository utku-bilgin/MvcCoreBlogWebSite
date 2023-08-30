using BLL.Abstract.IServices;
using BLL.Concrete.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BLL.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
