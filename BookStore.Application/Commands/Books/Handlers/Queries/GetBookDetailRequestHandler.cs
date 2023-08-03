using AutoMapper;
using BookStore.Application.Commands.Books.Requests.Queries;
using BookStore.Application.CustomsExceptions;
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
    public class GetBookDetailRequestHandler : IRequestHandler<GetBookDetailsRequest, BooksDto>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public GetBookDetailRequestHandler(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task<BooksDto> Handle(GetBookDetailsRequest request, CancellationToken cancellationToken)
        {

            var book = await _booksRepository.Get(request.Id);

            if (book == null)
            {
                throw new NotFoundException("Такого значения нет", request.Id);
            }

            return _mapper.Map<BooksDto>(book);

        }
    }
}
