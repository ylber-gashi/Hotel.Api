using Hotel.Api.Application.Common.Models;
using Hotel.Api.Domain.Entities;
using Hotel.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext context;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, ApplicationDbContext context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.context = context;
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {roleId} cannot be found!";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                Users = userManager.Users.ToList()
            };

            model.Users = (List<User>)await userManager.GetUsersInRoleAsync(role.Name);
            ViewBag.CanRemoveUsers = model.Users.Where(x => x.Id != userManager.GetUserAsync(User).Result.Id).ToList();
            ViewBag.OtherUsers = context.Users.ToList().Except(model.Users);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel editRole)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(editRole.RoleId);
                role.Name = editRole.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            editRole.Users = (List<User>)await userManager.GetUsersInRoleAsync(editRole.RoleId);
            ViewBag.OtherUsers = context.Users.ToList().Except(editRole.Users);
            return View(editRole);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string userId, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {roleId} cannot be found!";
                return View("NotFound");
            }
            var user = await userManager.FindByIdAsync(userId);
            var result = await userManager.AddToRoleAsync(user, role.Name);
            return RedirectToAction("EditRole", new { roleId = roleId });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUserFromRole(string userId, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {roleId} cannot be found!";
                return View("NotFound");
            }
            var user = await userManager.FindByIdAsync(userId);
            var result = await userManager.RemoveFromRoleAsync(user, role.Name);
            return RedirectToAction("EditRole", new { roleId = roleId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            var delete = await userManager.DeleteAsync(user);
            if (delete.Succeeded)
            {
                return RedirectToAction("AllUsers", "Account");
            }
            var errors = new List<IdentityError>();
            foreach (var error in delete.Errors)
            {
                errors.Add(error);
            }
            ViewBag.ErrorMessage = errors;
            List<User> users = context.Users.ToList();
            return View("AllUsers", users);
        }
    }
}
