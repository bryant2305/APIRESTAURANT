using ApiRestaurant.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS.Tables
{
    public class TablesCreateDto
    {
        public string Name { get; set; }
        public int PeopleCuantity { get; set; }

        public string Description { get; set; }
        public int Status { get; set; }

    }
}
