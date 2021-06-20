using Hotel.Api.Application.Common.Models.DashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Common.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetDashboardAsync();
    }
}
