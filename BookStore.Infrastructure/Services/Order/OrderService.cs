using BookStore.Application.CustomsExceptions;
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
        /// <summary>
        ///  Можно вынести это в отдельый таск репозитория
        ///  и там использовать IQueryable<Object>
        ///  после чего перебрать фильтры и вернуть только результат.
        /// </summary>
        /// <param name="id">номер</param>
        /// <param name="orderDate">дата заказа</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<List<GetOrdersDto>> GetOrdersByFilter(int? id, DateTime? orderDate)
        {
            var items = await _ordersItemsRepository.GetOrderedItemsAsync();

            if(id.HasValue)
            {
                //Если у нас заполнен ID, ищем.
                items = items.Where(x=>x.Order.Id.Equals(id.Value)).ToList();
            }

            if(orderDate.HasValue || orderDate > DateTime.MinValue)
            {
                //Если у нас заполнена дата, ищем
                items = items.Where(x=>x.Order.DateCreated >= orderDate).ToList();
            }

            if (!items.Any())
            {
                //Если пусто, выбиваем эксепешен
                throw new NotFoundException("ничего не найдено", nameof(GetOrdersByFilter));
            }


            //группируем покупки по имени пользователя.
            var groupedByUser = items.GroupBy(x => x.Order.CustomerName).ToDictionary(g => g.Key, g => g.ToList());

            //составляем модель результата.
            //она нужна для того, чтобы возвращать пользователю только необходимые данные,
            //не нужно же возвращать дату добавления в бд и т.д
            var result = groupedByUser.Select(group => new GetOrdersDto
            {
                Name = group.Key,
                Books = group.Value.Select(p=> new BooksDto 
                {
                    Id = p.Book.Id,
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
