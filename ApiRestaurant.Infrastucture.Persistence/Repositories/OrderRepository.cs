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
    public class OrderRepository : GenericRepository <Order> , IOrderRepository
    {
        private readonly RestaurantContext _dbContext;

        public OrderRepository(RestaurantContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Order> GetOrderWithDishesAsync(int orderId)
        {
            return await _dbContext.Orders
                .Include(o => o.OrderDishes)
                .ThenInclude(od => od.Dish)
                .FirstOrDefaultAsync(o => o.ID == orderId);
        }
    }
}
