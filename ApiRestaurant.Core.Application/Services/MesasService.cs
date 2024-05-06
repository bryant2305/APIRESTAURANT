using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.ViewModels.Tables;
using ApiRestaurant.Core.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Services
{
    public class MesasService : GenericService <MesasViewModel , SaveMesasViewModel , Mesas> , IMesasService
    {
        public MesasService(IGenericRepository<Mesas> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
