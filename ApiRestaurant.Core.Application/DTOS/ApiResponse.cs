using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS
{
    public class ApiResponse
    {
        public HttpStatusCode statusCode { get; set; }

        public bool IsOk { get; set; } = true;

        public List<string> ErrorMessage { get; set; }

        public object result { get; set; }
    }
}
