using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Infrastucture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Infrastucture.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly RestaurantContext _dbcontext;

        public GenericRepository(RestaurantContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public virtual async Task<Entity> AddAsync(Entity entity)
        {
            await _dbcontext.Set<Entity>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(Entity entity, int ID)
        {
            Entity etry = await _dbcontext.Set<Entity>().FindAsync(ID);
            _dbcontext.Entry(etry).CurrentValues.SetValues(entity);
            await _dbcontext.SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(Entity entity)
        {
            _dbcontext.Set<Entity>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public virtual async Task<List<Entity>> GetAllAsync()
        {
            return await _dbcontext.Set<Entity>().ToListAsync();
        }
        public virtual async Task<Entity> GetByIdAsync(int Id)
        {
            return await _dbcontext.Set<Entity>().FindAsync(Id);
        }

        public virtual async Task<List<Entity>> GetAllWhitIncludes(List<string> properties)
        {
            var query = _dbcontext.Set<Entity>().AsQueryable();
            foreach (var property in properties)
            {
                query = query.Include(property);
            }
            return await query.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}