using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.ViewModels.Tables
{
    public class SaveMesasViewModel
    {
        [JsonIgnore]
        public int ID { get; set; }

        [Required(ErrorMessage = "Debe proporcionar el nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe proporcionar la cantidad maxima de personas que acepta la mesa")]
        public int CantidadPersonas { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
