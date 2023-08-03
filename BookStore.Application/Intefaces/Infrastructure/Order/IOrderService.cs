using BookStore.Application.DTOs.Orders;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Intefaces.Infrastructure.Order
{
    public interface IOrderService
    {
        Task<List<GetOrdersDto>> GetOrdersByFilter(int? id, DateTime? orderDate);
    }
}
