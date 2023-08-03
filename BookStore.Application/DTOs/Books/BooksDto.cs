using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs.Books
{
    public class BooksDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }

        public string? ImageUrl { get; set; }

        public int Rating { get; set; }
        public int Stock { get; set; }
        public int TotalPages { get; set; }

        public int? Year { get; set; }
        public double? Price { get; set; }
    }
}
