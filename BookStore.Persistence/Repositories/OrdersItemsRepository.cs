using BookStore.Application.Intefaces.Persistence;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class OrdersItemsRepository : GenericRepository<OrderedItems>, IOrdersItemsRepository
    {
        public OrdersItemsRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}
