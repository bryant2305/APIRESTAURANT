using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.ViewModels.Orders
{
    public class SaveOrderViewModel
    {
        [JsonIgnore]
        public int ID { get; set; }

        [Required(ErrorMessage = "Debe proporcionar el DishSelected")]
        public string DishSelected { get; set; }

        [Required(ErrorMessage = "Debe proporcionar el Subtotal")]

        public string Subtotal { get; set; }

        [Required(ErrorMessage = "Debe proporcionar el Status")]

        public string Status { get; set; }
    }
}
