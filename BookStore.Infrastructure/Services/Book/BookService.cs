using AutoMapper;
using BookStore.Application.CustomsExceptions;
using BookStore.Application.DTOs.Books;
using BookStore.Application.Intefaces.Infrastructure.Book;
using BookStore.Application.Intefaces.Persistence;

namespace BookStore.Infrastructure.Services.Book
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BookService(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        /// <summary>
        ///  Можно вынести это в отдельый таск репозитория
        ///  и там использовать IQueryable<Object>
        ///  после чего перебрать фильтры и вернуть только результат.
        /// </summary>
        /// <param name="title">Название книги</param>
        /// <param name="year">Год книги</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<List<BooksDto>> GetBooksByFilter(string? title, int? year)
        {
            var books = await _booksRepository.GetAll();

            if(!string.IsNullOrEmpty(title) || !string.IsNullOrWhiteSpace(title))
            {
                //Если у нас заполнено название книги, ищем.
                books = books.Where(t => t.Title.ToLower().Contains(title.ToLower())).ToList();
            }

            if(year.HasValue)
            {
                //Если год книги выбран
                books = books.Where(y => y.Year.Equals(year)).ToList();
            }

            if(!books.Any()) 
            {
                //Если ничего не нашли, выбивает экспешен, который обрабатывается в Middleware
                throw new NotFoundException("ничего не найдено", nameof(GetBooksByFilter));
            }


            //Маппинг и возвращаем.
            return _mapper.Map<List<BooksDto>>(books);

        }
    }
}
