using BookStore.Application.DTOs.Books;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Commands.Books.Requests.Queries
{
    public class GetBookDetailsRequest : IRequest<BooksDto>
    {
        public int Id { get; set; }
    }
}
