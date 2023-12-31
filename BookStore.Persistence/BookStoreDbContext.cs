﻿using BookStore.Domain;
using BookStore.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderedItems> OrderedItems { get; set; }
    }
}
