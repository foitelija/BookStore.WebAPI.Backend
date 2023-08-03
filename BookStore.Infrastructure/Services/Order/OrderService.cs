using BookStore.Application.DTOs.Books;
using BookStore.Application.DTOs.Orders;
using BookStore.Application.Intefaces.Infrastructure.Order;
using BookStore.Application.Intefaces.Persistence;

namespace BookStore.Infrastructure.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersItemsRepository _ordersItemsRepository;

        public OrderService(IOrdersItemsRepository ordersItemsRepository)
        {
            _ordersItemsRepository = ordersItemsRepository;
        }
        public async Task<List<GetOrdersDto>> GetOrdersByFilter(int? id, DateTime? orderDate)
        {
            var items = await _ordersItemsRepository.GetOrderedItemsAsync();

            if(id.HasValue)
            {
                items = items.Where(x=>x.Order.Id.Equals(id.Value)).ToList();
            }

            if(orderDate.HasValue || orderDate > DateTime.MinValue)
            {
                items = items.Where(x=>x.Order.DateCreated >= orderDate).ToList();
            }

            var groupedByUser = items.GroupBy(x => x.Order.CustomerName).ToDictionary(g => g.Key, g => g.ToList());

            var result = groupedByUser.Select(group => new GetOrdersDto
            {
                Name = group.Key,
                Books = group.Value.Select(p=> new BooksDto 
                {
                    Author = p.Book.Author,
                    Description = p.Book.Description,
                    Genre = p.Book.Genre,
                    ImageUrl = p.Book.ImageUrl,
                    Price = p.Book.Price,
                    Rating = p.Book.Rating,
                    Stock = p.Book.Stock,
                    Title = p.Book.Title,
                    TotalPages = p.Book.TotalPages,
                    Year = p.Book.Year,
                }).ToList(),
            }).ToList();


            return result;
        }
    }
}
