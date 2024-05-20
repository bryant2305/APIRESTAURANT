using ApiRestaurant.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Domain.Entity
{
    public class Ingredient : AuditableBaseEntity
    {
        public string Name { get; set; }

        public ICollection<DishIngredients> Ingredients { get; set; }
    }
}
