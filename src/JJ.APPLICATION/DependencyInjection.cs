using JJ.APPLICATION.Interfaces;
using JJ.APPLICATION.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JJ.APPLICATION
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceProduct, ProductService>();

            return services;
        }
    }
}
