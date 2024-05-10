﻿using ApiRestaurant.Core.Domain.Common;
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
        public Mesas Mesas { get; set; } // Navigation property for Mesas
        public ICollection<OrderDish> OrderDishes { get; set; }

    }
}
