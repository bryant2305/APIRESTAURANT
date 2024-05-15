using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.DTOS.Account
{
    public class LoginResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
        public string JWToken { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
