﻿using BookStore.Application.Intefaces.Persistence;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class BooksRepository : GenericRepository<Books>, IBooksRepository
    {
        private readonly BookStoreDbContext _context;

        public BooksRepository(BookStoreDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
