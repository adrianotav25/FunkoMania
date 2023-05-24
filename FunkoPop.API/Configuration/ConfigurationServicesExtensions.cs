using FunkoMania.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FunkoMania.API.Configuration
{
    public static class ConfigurationServicesExtensions
    {
        public static IServiceCollection DbContextConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionstring = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<FunkoManiaDbContext>(options => options.UseSqlServer(connectionstring));

            services.AddDistributedMemoryCache();

            return services;
        }
    }
}
