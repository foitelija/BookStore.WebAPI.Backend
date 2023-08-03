using BookStore.Application.Intefaces.Persistence;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class OrdersItemsRepository : GenericRepository<OrderedItems>, IOrdersItemsRepository
    {
        private readonly BookStoreDbContext _context;

        public OrdersItemsRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<OrderedItems>> GetOrderedItemsAsync()
        {
            var ordered = await _context.OrderedItems.Include(b=>b.Book).Include(o=>o.Order).ToListAsync();
            return ordered;
        }
    }
}
