using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.ViewModels.Orders
{
    public class OrderViewModel
    {

        [JsonIgnore]
        public int ID { get; set; }
        public string DishSelected { get; set; }

        public string Subtotal { get; set; }

        public string Status { get; set; }
    }
}
