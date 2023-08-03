using BookStore.Application.Intefaces.Infrastructure.Book;
using BookStore.Infrastructure.Services.Book;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
