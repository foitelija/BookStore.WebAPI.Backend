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
    public class OrdersRepository : GenericRepository<Orders>, IOrdersRepository
    {
        private readonly BookStoreDbContext _context;

        public OrdersRepository(BookStoreDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
