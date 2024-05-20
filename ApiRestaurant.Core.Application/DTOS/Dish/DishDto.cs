using ApiRestaurant.Core.Application.DTOS.Ingredients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS.Dish
{
    public class DishDto
    {
            public int ID { get; set; } 
            public string Name { get; set; }  
            public double Price { get; set; }
            public int AmountPeople { get; set; }
            public string Category { get; set; }
            public List<IngredientDto> Ingredients { get; set; }
        }
    }

