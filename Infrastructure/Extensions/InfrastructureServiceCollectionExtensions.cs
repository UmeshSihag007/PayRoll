using ApwPayroll_Application.Interfaces.Services;
using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Interfaces;
using ApwPayroll_Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApwPayroll_Infrastructure.Extensions
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices();

            services.AddJwtAuthentication(configuration);
        }



        private static void AddServices(this IServiceCollection services)
        {
            services
           .AddHttpContextAccessor()
                .AddTransient<IJwtService, JwtService>()
                .AddTransient<IMediator, Mediator>()
               .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
        }
        private static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // Add JWT authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Changed here
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
          services.AddAuthentication(options =>
          {
              options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
              options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          })
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/Administration/Denied";
        options.Cookie.Name = "AppCookie";
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromDays(60);
        options.LoginPath = "/Administration/Login";
        options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
        options.SlidingExpiration = true;
    });
        }
    }
}

