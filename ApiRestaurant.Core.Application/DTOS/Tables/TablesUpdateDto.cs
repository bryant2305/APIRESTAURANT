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

        public string Name { get; set; }
        public int PeopleCuantity { get; set; }

        public string Description { get; set; }
        public int Status { get; set; }

    }
}
