using Hotel.Api.Application.Common.Models;
using Hotel.Api.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hotel.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountsService _accountsService;

        public AccountController(AccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountsService.RegisterUserAsync(registerModel);
                if (result.Succeeded)
                {
                    try
                    {
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("http://localhost:3000");
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.ConnectionClose = true;
                        var body = new Dictionary<string, string>();
                        body.Add("email", registerModel.Email);
                        var jsonString = JsonConvert.SerializeObject(body);
                        var stringContent = new StringContent(jsonString);
                        var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/email");
                        requestMessage.Content = stringContent;
                        var task = client.SendAsync(requestMessage);
                        var response = task.Result;
                    }
                    catch
                    {

                    }
                    return RedirectToAction("Dashboard", "Dashboard");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(registerModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountsService.LoginUserAsync(loginModel);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Dashboard", "Dashboard");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }

            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _accountsService.LogOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet("users")]
        [AllowAnonymous]
        public async Task<IActionResult> AllUsers()
        {
            var users = await _accountsService.GetAllUsersAsync();

            return View(users);
        }
    }
}