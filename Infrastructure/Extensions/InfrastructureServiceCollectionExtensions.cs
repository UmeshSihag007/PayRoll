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
            // Add JWT and Cookie authentication
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Optional, if you use cookies for signing in
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidIssuer = configuration["Jwt:Issuer"],
            //        ValidAudience = configuration["Jwt:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true
            //    };
            //})
            //.AddCookie(options =>
            //{
            //    options.LoginPath = "/Administration/Login";
            //});
        }

    }

}

