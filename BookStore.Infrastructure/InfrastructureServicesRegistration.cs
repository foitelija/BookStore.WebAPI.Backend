using BookStore.Application.Intefaces.Infrastructure.Book;
using BookStore.Application.Intefaces.Infrastructure.Order;
using BookStore.Infrastructure.Services.Book;
using BookStore.Infrastructure.Services.Order;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
