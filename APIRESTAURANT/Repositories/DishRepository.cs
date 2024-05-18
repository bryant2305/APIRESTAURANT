using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Domain.Entity;
using ApiRestaurant.Infrastucture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Infrastucture.Persistence.Repositories
{
    public class DishRepository : GenericRepository < Dish> , IDishRepository
    {
        private readonly RestaurantContext _dbContext;

        public DishRepository(RestaurantContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Dish>> GetAllDishesWithIngredientsAsync()
        {
            return await _dbContext.Dishes
                                 .Include(d => d.Ingredients)
                                 .ThenInclude(di => di.Ingredient)
                             .ToListAsync();
        }
        public async Task<Dish> GetADisheWithIngredientsAsync(int ingId)
        {
            return await _dbContext.Dishes
                                 .Include(d => d.Ingredients
                                 )
                                 .ThenInclude(di => di.Ingredient)
                             .FirstOrDefaultAsync(o => o.ID == ingId);
        }
    }
}
