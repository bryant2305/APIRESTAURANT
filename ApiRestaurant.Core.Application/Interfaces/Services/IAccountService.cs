using ApiRestaurant.Core.Application.DTOS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
