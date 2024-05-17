using ApiRestaurant.Core.Application.ViewModels.DishIngredients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS.Dish
{
    public class DishCreateDto
    {

        [Required(ErrorMessage = "You should add a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should add a price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "You should add an amount of people")]
        public int AmountPeople { get; set; }

        [Required(ErrorMessage = "You should add a Category")]
        public string Category { get; set; }
        public List<DishIngredientViewModel> ingredients { get; set; }
    }
}
