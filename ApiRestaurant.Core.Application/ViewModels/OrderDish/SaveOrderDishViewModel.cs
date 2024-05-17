
using ApiRestaurant.Core.Application.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.ViewModels.OrderDish
{
    public class SaveOrderDishViewModel
    {
        public int TableID { get; set; }

        public int DishID { get; set; }

        public SaveOrderViewModel Orders { get; set; }

        //public SaveMesasViewModel Dishs { get; set; }

    }
}

