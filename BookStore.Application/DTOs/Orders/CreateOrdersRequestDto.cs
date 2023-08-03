using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs.Orders
{
    public class CreateOrdersRequestDto
    {
        public string CustomerName { get; set; }
        public List<int> BookIds { get; set; }
    }
}
