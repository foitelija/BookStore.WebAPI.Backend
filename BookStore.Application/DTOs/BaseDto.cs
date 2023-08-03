using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; } 
    }
}
