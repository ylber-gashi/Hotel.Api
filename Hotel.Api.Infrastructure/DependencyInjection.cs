using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Application.Services;
using Hotel.Api.Domain.Entities;
using Hotel.Api.Infrastructure.Persistence;
using Hotel.Api.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("ConnectionString"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped(typeof(IEntityRepository<>),typeof(EntityRepository<>));
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<DashboardService>();
            services.AddScoped<AccountsService>();

            return services;
        }
    }
}