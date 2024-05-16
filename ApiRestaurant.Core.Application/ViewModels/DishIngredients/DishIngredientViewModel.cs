using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.ViewModels.DishIngredients
{
    public class DishIngredientViewModel
    {
        //[JsonIgnore]
        //public int ID { get; set; }

        public int IngredientID { get; set; }

       // public int DishID { get; set; }
    }
}
