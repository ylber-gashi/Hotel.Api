using Hotel.Api.Application.Common.Models;
using Hotel.Api.Application.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Api.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly AccountsHelper _accountsHelper;
        public AccountsController(AccountsHelper accountsHelper)
        {
            this._accountsHelper = accountsHelper;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {
            return Ok(await _accountsHelper.RegisterUserAsync(registerModel, HttpContext));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            return Ok(await _accountsHelper.LoginUserAsync(loginModel, HttpContext));
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