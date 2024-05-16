using ApiRestaurant.Core.Application.DTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.ViewModels.Tables
{
    public class MesasViewModel
    {
        //[JsonIgnore]
        //public int ID { get; set; }
        public string Nombre { get; set; }
        public int CantidadPersonas { get; set; }

        public string Descripcion { get; set; }
        public string Estado { get; set; }

    }
}
