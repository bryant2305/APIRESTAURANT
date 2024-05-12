﻿using ApiRestaurant.Core.Application.ViewModels.Dish;
using ApiRestaurant.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Interfaces.Services
{
    public interface IDishService : IGenericService<DishViewModel , SaveDishViewModel ,Dish>
    {
        Task<List<SaveDishViewModel>> GetAllViewModelWhitInclude();
    }
}
