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

        /// <summary>
        /// Создание нового заказа.
        /// </summary>
        /// <param name="createOrders">
        ///  Принимает модель: имя пользователя и список выбранных книг
        /// </param>
        /// <returns>
        /// Возвращает созданную модель.
        /// </returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        /// <response code="400">Ошибка запроса</response>
        /// 
        [HttpPost("create-new-order")]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrdersRequestDto createOrders)
        {
            var command = new CreateOrderCommand { OrdersRequestDto = createOrders };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Получение списка заказов.
        /// </summary>
        /// <param name="GetOrders">
        ///  Принимает модель: ID и дату закзаа
        /// </param>
        /// <returns>
        /// Возвращает созданную модель.
        /// </returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="500">Ошибка на стороне сервера</response>
        /// <response code="404">Данные не найдены</response>
        /// 
        [HttpGet("get-orders-by-filter")]
        public async Task<ActionResult> GetOrders([FromQuery] int? id, DateTime? orderDate)
        {
            var items = await _orderService.GetOrdersByFilter(id, orderDate);
            return Ok(items);
        }
    }
}
