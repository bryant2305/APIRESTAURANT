using ApiRestaurant.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Domain.Entity
{
    public class Mesas : AuditableBaseEntity
    {
        public string Name { get; set; }
        public int PeopleCuantity { get; set; }

        public string Description { get; set; }
        public int Status { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
