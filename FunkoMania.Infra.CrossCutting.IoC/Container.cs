using FunkoMania.Domain.Interfaces;
using FunkoMania.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FunkoMania.Infra.CrossCutting.IoC
{
    public static class Container
    {
        public static IServiceCollection AddNativeInjectorBootStrapper(this IServiceCollection services)
        {
            return services;
        }

        public static void AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.Load("FunkoMania.Domain"));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

        }
    }
}
