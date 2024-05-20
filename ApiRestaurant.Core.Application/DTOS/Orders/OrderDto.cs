using ApiRestaurant.Core.Application.DTOS.Dish;
using ApiRestaurant.Core.Application.DTOS.Ingredients;
using ApiRestaurant.Core.Application.DTOS.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS.Orders
{
    public class OrderDto
    { 
        public int ID { get; set; }
        public string DishSelected { get; set; }

        public string Subtotal { get; set; }

        public string Status { get; set; }

        public int TableId { get; set; }
        public List<DishDto> Dishes { get; set; }


        //public List<TablesDto> Table { get; set; }
    }
}
