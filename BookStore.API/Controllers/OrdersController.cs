using BookStore.Application.Commands.Orders.Requests.Commands;
using BookStore.Application.DTOs.Orders;
using BookStore.Application.Intefaces.Infrastructure.Order;
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
        private readonly IOrderService _orderService;

        public OrdersController(IMediator mediator, IOrderService orderService)
        {
            _mediator = mediator;
            _orderService = orderService;
        }

        [HttpPost("create-new-order")]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrdersRequestDto createOrders)
        {
            var command = new CreateOrderCommand { OrdersRequestDto = createOrders };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("get-orders-by-filter")]
        public async Task<ActionResult> GetOrders([FromQuery] int? id, DateTime? orderDate)
        {
            var items = await _orderService.GetOrdersByFilter(id, orderDate);
            return Ok(items);
        }
    }
}
