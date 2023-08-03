using BookStore.Application.DTOs.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Commands.Orders.Requests.Commands
{
    public class CreateOrderCommand : IRequest<CreateOrdersRequestDto>
    {
        public CreateOrdersRequestDto OrdersRequestDto { get; set; }
    }
}
