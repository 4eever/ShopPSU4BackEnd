using BusinessAccessLayer.Mappings;
using BusinessAccessLayer.Services.Implemertaions;
using BusinessAccessLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Implemertaions;
using DataAccessLayer.Repositories.Interfaces;

namespace Web_Api
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            AddRepositories(services);
            AddAutoMapperProfiles(services);
            AddServices(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ICategotyRepository, CategotyRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        }

        private static void AddAutoMapperProfiles(IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(AutoMapperCategoryProfile),
                typeof(AutoMapperOrderProfile),
                typeof(AutoMapperOrderItemProfile),
                typeof(AutoMapperProductProfile),
                typeof(AutoMapperUserProfile)
);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
