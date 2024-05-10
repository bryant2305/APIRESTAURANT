using ApiRestaurant.Core.Application.ViewModels.Orders;
using ApiRestaurant.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Interfaces.Services
{
    public interface IOrderService : IGenericService<OrderViewModel ,  SaveOrderViewModel , Order>
    {
    }
}
