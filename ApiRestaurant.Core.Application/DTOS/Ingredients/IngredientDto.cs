using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS.Ingredients
{
    public class IngredientDto
    {

        public int ID { get; set; }

        public string Name { get; set; }

    }
}
