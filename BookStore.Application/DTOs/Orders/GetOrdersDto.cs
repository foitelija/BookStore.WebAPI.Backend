using BookStore.Application.DTOs.Books;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs.Orders
{
    public class GetOrdersDto
    {
        public string Name { get; set; }
        public List<BooksDto> Books { get; set; }
    }
}
