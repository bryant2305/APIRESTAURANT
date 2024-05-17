using ApiRestaurant.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Domain.Entity
{
    public class DishIngredients : AuditableBaseEntity
    {
        public int DishId { get; set; }

        public int IngredientId { get; set; }

        public Dish Dish { get; set; }

        public Ingredient Ingredient { get; set; }


    }
}
