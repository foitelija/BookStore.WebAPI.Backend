using BookStore.Application.Intefaces.Persistence;
using BookStore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BookStoreConnection"));
            });

            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }

    }
}
