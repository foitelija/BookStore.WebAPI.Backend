using BookStore.Application.Commands.Orders.Requests.Commands;
using BookStore.Application.DTOs.Orders;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-new-order")]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrdersRequestDto createOrders)
        {
            var command = new CreateOrderCommand { OrdersRequestDto = createOrders };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
