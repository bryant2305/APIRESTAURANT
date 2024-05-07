using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.ViewModels.DishIngredients;
using ApiRestaurant.Core.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Services
{
    public class DishIngredientService : GenericService<DishIngredientViewModel , SaveDishIngredientViewModel, DishIngredients> ,IDishIngredientService
    {
        public DishIngredientService(IGenericRepository<DishIngredients> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
