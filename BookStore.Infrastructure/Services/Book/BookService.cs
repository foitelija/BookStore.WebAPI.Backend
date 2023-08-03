using AutoMapper;
using BookStore.Application.DTOs.Books;
using BookStore.Application.Intefaces.Infrastructure.Book;
using BookStore.Application.Intefaces.Persistence;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<BooksDto>> GetBooksByFilter(string? title, int? year)
        {
            var books = await _booksRepository.GetAll();

            if(!string.IsNullOrEmpty(title) || !string.IsNullOrWhiteSpace(title))
            {
                books = books.Where(t => t.Title.ToLower() == title.ToLower()).ToList();
            }

            if(year.HasValue)
            {
                books = books.Where(y => y.Year.Equals(year)).ToList();
            }


            return _mapper.Map<List<BooksDto>>(books);

        }
    }
}
