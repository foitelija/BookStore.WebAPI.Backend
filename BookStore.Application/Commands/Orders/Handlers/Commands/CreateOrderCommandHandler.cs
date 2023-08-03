using BookStore.Application.Commands.Orders.Requests.Commands;
using BookStore.Application.DTOs.Orders;
using BookStore.Application.DTOs.Orders.Validators;
using BookStore.Application.Intefaces.Persistence;
using BookStore.Domain;
using FluentValidation;
using MediatR;

namespace BookStore.Application.Commands.Orders.Handlers.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrdersRequestDto>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrdersItemsRepository _ordersItemsRepository;

        public CreateOrderCommandHandler(IOrdersRepository ordersRepository, IOrdersItemsRepository ordersItemsRepository)
        {
            _ordersRepository = ordersRepository;
            _ordersItemsRepository = ordersItemsRepository;
        }
        public async Task<CreateOrdersRequestDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateOrderValidator();

            var validationResult = await validator.ValidateAsync(request.OrdersRequestDto);

            if(validationResult.IsValid == false)
            {
                var errors = validationResult.Errors.Select(e=>e.ErrorMessage);
                throw new ValidationException("Данные не валидны");
            }

            var placedOrder = await _ordersRepository.Add(new Domain.Orders { CustomerName = request.OrdersRequestDto.CustomerName });

            foreach(var books in request.OrdersRequestDto.BookIds)
            {
                await _ordersItemsRepository.Add(new OrderedItems { BookId = books, OrderId = placedOrder.Id});
            }

            return request.OrdersRequestDto;
        }
    }
}
