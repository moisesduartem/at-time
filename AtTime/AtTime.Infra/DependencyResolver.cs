using AtTime.Infra.Database;
using AtTime.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AtTime.Infra
{
    public static class DependencyResolver
    {
        public static void AddConfiguration(this IServiceCollection services)
        {
            AddDependencyInjection(services);
            AddEntityFrameworkCore(services);
        }

        private static void AddDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<DataContext, DataContext>();
        }
        
        private static void AddEntityFrameworkCore(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("AtTimeDB"));
        }
    }
}
