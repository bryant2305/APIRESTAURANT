using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Domain.Common
{
    public class AuditableBaseEntity
    {
        public virtual int ID { get; set; }

        public string? CreatedBy { get; set; }
        
        public DateTime? Created { get; set; }

        public string? LastModifyBy { get; set; }

        public DateTime? LastModify { get; set; }
    }

    }
