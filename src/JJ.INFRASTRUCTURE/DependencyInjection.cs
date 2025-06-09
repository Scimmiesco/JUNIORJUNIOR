using JJ.DOMAIN.Interfaces.Repositorys;
using JJ.INFRASTRUCTURE.Context;
using JJ.INFRASTRUCTURE.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JJ.INFRASTRUCTURE
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly("JJ.INFRASTRUCTURE");
                })
            );

            services.AddScoped<IRepositoryProduct, RepositoryProduct>();

            return services;
        }
    }
}
