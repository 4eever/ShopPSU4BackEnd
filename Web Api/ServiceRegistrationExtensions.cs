using BusinessAccessLayer.Mappings;
using DataAccessLayer.Repositories;

namespace Web_Api
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            AddRepositories(services);
            AddAutoMapperProfiles(services);
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
    }
}
