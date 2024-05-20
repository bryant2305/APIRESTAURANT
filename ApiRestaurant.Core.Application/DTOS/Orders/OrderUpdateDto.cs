
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS.Orders
{
    public class OrderUpdateDto
    {
        public int ID { get; set; }
        public string DishSelected { get; set; }

        public string Subtotal { get; set; }

        public string Status { get; set; }

       // public List<OrderDishViewModel> Orders { get; set; }
    }
}
