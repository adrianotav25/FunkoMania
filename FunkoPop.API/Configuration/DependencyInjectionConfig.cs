using FunkoMania.Domain.Interfaces;
using FunkoMania.Domain.Shared.Transaction;
using FunkoMania.Infra.Data.Context;
using FunkoMania.Infra.Data.Repositories;
using FunkoMania.Infra.Data.UoW;
using MediatR;

namespace FunkoMania.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatR();
            services.AddRepositories();
            services.AddServices();

        }

        public static void AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.Load("FunkoMania.Domain"));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<FunkoManiaDbContext>();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IVoucherAppService, VoucherAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
        }
    }
}
