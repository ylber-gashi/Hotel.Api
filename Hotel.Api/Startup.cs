using Hotel.Api.Middleware;
using Hotel.Api.Application;
using Hotel.Api.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Hotel.Api.Domain.Entities;
using Hotel.Api.Infrastructure.Persistence;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;
using Hotel.Api.Application.Services;
using Hotel.Api.Application.Common.Interfaces;

namespace Hotel.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager<SignInManager<User>>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretTokenKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                     .AddJwtBearer(options =>
                     {
                         options.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidateIssuerSigningKey = true,
                             IssuerSigningKey = key,
                             ValidateIssuer = false,
                             ValidateAudience = false,
                         };

                         options.Events = new JwtBearerEvents
                         {
                             OnMessageReceived = context =>
                             {
                                 var accessToken = context.Request.Query["hotel_api_token"];
                                 var path = context.HttpContext.Request.Path;
                                 if (!string.IsNullOrEmpty(accessToken))
                                 {
                                     context.Token = accessToken;
                                 }

                                 return Task.CompletedTask;
                             }
                         };
                     });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowAnyOrigin();
                });
            });

            services.AddScoped<TokenService>();
            
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel.Api", Version = "v1" });
            });
            services.AddInfrastructure(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Codex.Clean.Sql.Template.Api v1"));
            }
            app.UseCustomExceptionHandlerMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
