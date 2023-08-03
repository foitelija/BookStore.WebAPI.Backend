using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Entities
{
    public class BooksEntityConfiguration : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.HasData(
                new Books
                {
                    Id = 1,
                    Title = "Test book name",
                    Author = "Author book name",
                    Description = "Full Description book",
                    Genre = "Genre test",
                    ImageUrl = "ImageUrl put here",
                    Rating = 4,
                    Stock = 20,
                    TotalPages = 200,
                    Year = 2000,
                    Price = 15.99
                },
                new Books
                {
                    Id = 2,
                    Title = "Test 2 book 2 name 2",
                    Author = "Author 2 book 2 name 2",
                    Description = "Full 2 Description 2 book 2",
                    Genre = "Genre 2 test 2",
                    ImageUrl = "ImageUrl 2 put 2 here",
                    Rating = 2,
                    Stock = 22,
                    TotalPages = 20,
                    Year = 2022,
                    Price = 2.00
                },
                new Books
                {
                    Id = 3,
                    Title = "Test 3 book 3 name",
                    Author = "Author 3 book 3 name",
                    Description = "Full 3 Description 3 book",
                    Genre = "Genre 3 test 3",
                    ImageUrl = "ImageUrl 3 put 3 here 3",
                    Rating = 5,
                    Stock = 33,
                    TotalPages = 33,
                    Year = 2013,
                    Price = 33.33
                }
                );
        }
    }
}
