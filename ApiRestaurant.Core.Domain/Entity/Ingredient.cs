using ApiRestaurant.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Domain.Entity
{
    public class Ingredient : AuditableBaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<DishIngredients> Ingredients { get; set; }
    }
}
