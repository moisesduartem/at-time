using AtTime.Infra.Database;
using AtTime.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AtTime.Infra
{
    public static class DependencyResolver
    {
        public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            AddDependencyInjection(services);
            AddEntityFrameworkCore(services, configuration);
        }

        private static void AddDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPointRepository, PointRepository>();
            services.AddScoped<DataContext, DataContext>();
        }
        
        private static void AddEntityFrameworkCore(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(DataContext).Assembly.FullName));
            });
        }
    }
}
