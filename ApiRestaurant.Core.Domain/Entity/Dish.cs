using ApiRestaurant.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Domain.Entity
{
    public class Dish : AuditableBaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int AmountPeople { get; set; }
        public string Category { get; set; }
        public List<DishIngredients> DishIngredients { get; set; }
        public ICollection<OrderDish> OrderDishes { get; set; }
    }
}
