
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS.Orders
{
    public class OrderUpdateDto
    {
        public List<int> DishIds { get; set; }
    }
}
