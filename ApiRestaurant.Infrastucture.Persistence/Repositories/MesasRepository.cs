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
    public class MesasRepository : GenericRepository<Mesas>, IMesasRepository
    {
        private readonly RestaurantContext _dbContext;

        public MesasRepository(RestaurantContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Mesas>> GetAllMesasWithOrderAsync()
        {
            return await _dbContext.Mesas
             .Include(m => m.Orders)
             .ThenInclude(o => o.OrderDishes)
             .ThenInclude(od => od.Dish).ToListAsync();
        }

        public async Task<Mesas> GetOrderAsync(int mesaId)
        {
            return await _dbContext.Mesas
             .Include(m => m.Orders)
             .ThenInclude(o => o.OrderDishes)
             .ThenInclude(od => od.Dish)
             .FirstOrDefaultAsync(m => m.ID == mesaId);
        }
    }
}
