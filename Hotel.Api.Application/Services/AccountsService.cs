using Hotel.Api.Application.Common.Exceptions;
using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models;
using Hotel.Api.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Services
{
    public class AccountsService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IApplicationDbContext _context;
        private readonly TokenService _tokenService;

        public AccountsService(IApplicationDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            TokenService tokenService)
        {
            this._context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._tokenService = tokenService;
        }

        public BaseResponse LogOutUser(HttpContext httpContext)
        {
            httpContext.Response.Cookies.Append("hotel_api_token", "noValue");
            return new BaseResponse { Success = true, Id = null };
        }

        public async Task<BaseResponse> RegisterUserAsync(RegisterModel registerModel)
        {
            if (registerModel.Password != registerModel.ConfirmPassword)
                throw new BadRequestException("Password", "Passwords must match");

            if (await _context.Users.FirstOrDefaultAsync(u => u.Email == registerModel.Email) != null)
                throw new BadRequestException("Email", "Email must be unique");

            if (await _context.Users.FirstOrDefaultAsync(u => u.UserName == registerModel.UserName) != null)
                throw new BadRequestException("Username", "Username must be unique");

            var user = new User
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            await _signInManager.SignInAsync(user, false);
            var loggedInUser = await _userManager.FindByEmailAsync(user.Email);

            return result.Succeeded ? new BaseResponse { Success = true, Id = loggedInUser.Id } : new BaseResponse { Success = false, Id = null };
        }

        public async Task<UserModel> GetCurrentUserAsync(ClaimsPrincipal currentUser)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == currentUser.FindFirstValue(ClaimTypes.Email));

            if (user is null)
                throw new NotFoundException("User", "There is no user logged in");

            return new UserModel
            {
                Token = _tokenService.CreateToken(user),
                Username = user.UserName,
                Id = user.Id,
                Email = user.Email,
                Gender = user.Gender
            };
        }

        public async Task<LoginResultModel> LoginUserAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user == null)
                throw new NotFoundException("Login", "Incorrect email or password");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

            if (result.Succeeded)
            {
                var token = _tokenService.CreateToken(user);
                var loggedUser = new UserModel
                {
                    Token = token,
                    Username = user.UserName,
                    Id = user.Id,
                    Email = user.Email,
                    Gender = user.Gender
                };

                return new LoginResultModel { Success = true, User = loggedUser };
            }
            else
            {
                return new LoginResultModel { Success = false, User = null };
            }
        }
    }
}
