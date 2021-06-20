using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Common.Models;
using Hotel.Api.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Services
{
    public class AccountsService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IApplicationDbContext _context;

        public AccountsService(IApplicationDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
             RoleManager<IdentityRole> roleManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterModel registerModel)
        {
            var user = new User
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                UserName = registerModel.Email,
                Email = registerModel.Email,
                Gender = registerModel.Gender
            };
            var result = new IdentityResult();
            if (!_userManager.Users.Any())
            {
                result = await _userManager.CreateAsync(user, registerModel.Password);

                IdentityRole identityRole = new IdentityRole { Name = "Admin" };
                await _roleManager.CreateAsync(identityRole);
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                result = await _userManager.CreateAsync(user, registerModel.Password);
                var checkRole = await _roleManager.RoleExistsAsync("Normal");
                if (!checkRole)
                {
                    IdentityRole identityRole = new IdentityRole { Name = "Normal" };
                    await _roleManager.CreateAsync(identityRole);
                }
                await _userManager.AddToRoleAsync(user, "Normal");
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return result;
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<SignInResult> LoginUserAsync(LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, false);
            return result;
        }
    }
}
