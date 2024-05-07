using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Domain.Entity;
using ApiRestaurant.Infrastucture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Infrastucture.Persistence.Repositories
{
    public class DishIngredientRepository : GenericRepository<DishIngredients> ,IDishIngredientsRepository
    {
        private readonly RestaurantContext _dbContext;

        public DishIngredientRepository(RestaurantContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
