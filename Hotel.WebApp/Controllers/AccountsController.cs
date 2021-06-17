using Hotel.Api.Application.Common.Models;
using Hotel.Api.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.WebApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AccountsService _accountsHelper;
        public AccountsController(AccountsService accountsHelper)
        {
            this._accountsHelper = accountsHelper;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {
            return Ok(await _accountsHelper.RegisterUserAsync(registerModel));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            return Ok(await _accountsHelper.LoginUserAsync(loginModel));
        }

        [HttpGet("logout")]
        public IActionResult LogOut()
        {
            return Ok(_accountsHelper.LogOutUser(HttpContext));
        }

        [Authorize]
        [HttpGet("currentUser")]
        public async Task<ActionResult> GetCurrentUser()
        {
            return Ok(await _accountsHelper.GetCurrentUserAsync(User));
        }
    }
}