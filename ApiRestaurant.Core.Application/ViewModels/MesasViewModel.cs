using ApiRestaurant.Core.Application.DTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.ViewModels
{
    public class MesasViewModel
    {
        //public int ID { get; set; }
        public string Nombre { get; set; }
        public int CantidadPersonas { get; set; }

        public string Descripcion { get; set; }
        public string Estado { get; set; }

    }
}
