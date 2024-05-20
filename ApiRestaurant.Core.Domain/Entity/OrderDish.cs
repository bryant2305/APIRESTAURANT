using ApiRestaurant.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Domain.Entity
{
    public class OrderDish : AuditableBaseEntity
    {
        public int OrderID { get; set; }
        public int DishID { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }

        [JsonIgnore]
        public Dish Dish { get; set; }
    }
}
