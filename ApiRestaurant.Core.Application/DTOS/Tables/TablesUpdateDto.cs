using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS.Tables
{
    public class TablesUpdateDto
    {

        [Required(ErrorMessage = "Debe proporcionar el nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe proporcionar la cantidad maxima de personas que acepta la mesa")]
        public int CantidadPersonas { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
