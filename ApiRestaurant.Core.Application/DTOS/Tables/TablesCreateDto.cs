using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS.Tables
{
    public class TablesCreateDto
    {
        public string Nombre { get; set; }
        public int CantidadPersonas { get; set; }

        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
