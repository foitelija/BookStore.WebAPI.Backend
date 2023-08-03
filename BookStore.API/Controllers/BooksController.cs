using BookStore.Application.Commands.Books.Requests.Queries;
using BookStore.Application.DTOs.Books;
using BookStore.Application.Intefaces.Infrastructure.Book;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBookService _bookService;

        public BooksController(IMediator mediator, IBookService bookService)
        {
            _mediator = mediator;
            _bookService = bookService;
        }
        [HttpGet("get-a-list-of-books-by-filter")]
        public async Task<ActionResult> GetBooksByFilter([FromQuery] string? title, [FromQuery] int? year)
        {
            var books = await _bookService.GetBooksByFilter(title, year);
            return Ok(books);
        }

        [HttpGet("get-a-single-book/{id}")]
        public async Task<ActionResult<BooksDto>> Get(int id)
        {

            var book = await _mediator.Send(new GetBookDetailsRequest { Id = id });
            return Ok(book);

        }
    }
}
