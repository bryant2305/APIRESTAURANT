using ApiRestaurant.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Domain.Entity
{
    public class Order : AuditableBaseEntity
    {
        public string DishSelected { get; set; }
        public string Subtotal { get; set; }
        public string Status { get; set; }
        public ICollection<OrderDish> OrderDishes { get; set; }

        public int TableId { get; set; }
        public Mesas Tables { get; set; }

    }
}
