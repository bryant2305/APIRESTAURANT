﻿using ApiRestaurant.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Interfaces.Repositories
{
    public interface IMesasRepository : IGenericRepository<Mesas>
    {
        Task<Mesas> GetOrderAsync(int mesaId);

        Task<List<Mesas>> GetAllMesasWithOrderAsync();
    }
}
