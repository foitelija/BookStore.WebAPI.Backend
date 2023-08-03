using AutoMapper;
using BookStore.Application.Commands.Books.Requests.Queries;
using BookStore.Application.DTOs.Books;
using BookStore.Application.Intefaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Commands.Books.Handlers.Queries
{
    public class GetBookListRequestHandler : IRequestHandler<GetBookListRequest, List<BooksDto>>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public GetBookListRequestHandler(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }
        public async Task<List<BooksDto>> Handle(GetBookListRequest request, CancellationToken cancellationToken)
        {
            var books = await _booksRepository.GetAll();
            return _mapper.Map<List<BooksDto>>(books);
        }
    }
}
