
using ApiRestaurant.Core.Application.DTOS.Tables;
using ApiRestaurant.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS.Orders
{
    public class OrderCreateDto
    {
        public string DishSelected { get; set; }

        public string Subtotal { get; set; }

        public string Status { get; set; }

        public List<int> DishIds { get; set; }
    }
}
