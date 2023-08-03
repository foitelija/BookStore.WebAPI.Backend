using BookStore.Application.DTOs.Books;

namespace BookStore.Application.Intefaces.Infrastructure.Book
{
    public interface IBookService
    {
        Task<List<BooksDto>> GetBooksByFilter(string? title, int? year);
    }
}
