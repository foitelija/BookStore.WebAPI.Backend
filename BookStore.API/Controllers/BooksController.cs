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
        /// <summary>
        /// Получение книжек по фильтрам
        /// </summary>
        /// <param name="GetBooksByFilter">
        ///  Принимает: название, год выпуска
        /// </param>
        /// <returns>
        /// Возвращает созданную модель.
        /// </returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        /// <response code="404">Ничего не найдено</response>
        /// 
        [HttpGet("get-a-list-of-books-by-filter")]
        public async Task<ActionResult> GetBooksByFilter([FromQuery] string? title, [FromQuery] int? year)
        {
            var books = await _bookService.GetBooksByFilter(title, year);
            return Ok(books);
        }

        /// <summary>
        /// Получение книги по ID
        /// </summary>
        /// <param name="Get">
        ///  Принимает: ID
        /// </param>
        /// <returns>
        /// Возвращает созданную модель.
        /// </returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        /// <response code="404">Ничего не найдено</response>
        /// 
        [HttpGet("get-a-single-book/{id}")]
        public async Task<ActionResult<BooksDto>> Get(int id)
        {
            var book = await _mediator.Send(new GetBookDetailsRequest { Id = id });
            return Ok(book);
        }
    }
}
