using ApiRestaurant.Core.Application.DTOS.Account;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Infrastructure.Identity.Services;
using APIRESTAURANT.Controllers.v1;
using Microsoft.AspNetCore.Mvc;

namespace APIRESTAURANT.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            return Ok(await _accountService.LoginAsync(request));
        }

    }
}
