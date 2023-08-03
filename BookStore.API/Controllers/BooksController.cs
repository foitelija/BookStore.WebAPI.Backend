using BookStore.Application.Commands.Books.Requests.Queries;
using BookStore.Application.DTOs.Books;
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

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-a-list-of-books-by-filter")]
        public async Task<ActionResult> GetBooksByFilter([FromQuery] string? title, [FromQuery] int? year)
        {
            return Ok();
        }

        [HttpGet("get-a-single-book/{id}")]
        public async Task<ActionResult<BooksDto>> Get(int id)
        {
            try
            {
                var book = await _mediator.Send(new GetBookDetailsRequest { Id = id });
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
