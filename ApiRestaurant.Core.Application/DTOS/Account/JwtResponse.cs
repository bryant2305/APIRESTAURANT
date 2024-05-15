using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS.Account
{
    public class jwtResponse
    {
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
