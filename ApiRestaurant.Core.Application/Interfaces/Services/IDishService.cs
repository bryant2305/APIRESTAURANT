using ApiRestaurant.Core.Application.ViewModels.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Interfaces.Services
{
    public interface IDishService : IGenericService<DishViewModel , SaveDishViewModel ,DishViewModel>
    {
        Task<List<SaveDishViewModel>> GetAllViewModelWhitInclude();
    }
}
