using Hotel.Api.Application.Common.Models.DashboardModels;
using Hotel.Api.Application.Services;
using Hotel.Api.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DashboardService dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        [HttpGet("dashboard")]
        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var dashboard = await dashboardService.GetDashboardAsync();
            return View(dashboard);
        }

    }
}
