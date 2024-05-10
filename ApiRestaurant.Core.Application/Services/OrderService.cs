using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.ViewModels.Orders;
using ApiRestaurant.Core.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Services
{
    public class OrderService : GenericService<OrderViewModel, SaveOrderViewModel, Order>, IOrderService
    {
        public OrderService(IGenericRepository<Order> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
