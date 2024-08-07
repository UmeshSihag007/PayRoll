using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApwPayroll_Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        private readonly IUnitOfWork _unitOfWork;
        private  readonly IHttpContextAccessor _httpContextAccessor;
        public JwtService(IConfiguration configuration, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> GenerateToken(string userId)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            //var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id",  "1"),

                    new Claim(ClaimTypes.Name, "Testing"),


                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512),


            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
           
            // Check if the token is already present in the cookie
            var existingToken = _httpContextAccessor.HttpContext.Request.Cookies["Token"];
            if (!string.IsNullOrEmpty(existingToken))
            {
                // Update the existing token
                _httpContextAccessor.HttpContext.Response.Cookies.Delete("Token");
            }

            // Configure cookie options
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(60),
                SameSite = SameSiteMode.Strict,
                Secure = true // Ensure this is true in production environments
            };

            // Add the token to the cookies
            _httpContextAccessor.HttpContext.Response.Cookies.Append("Token", jwtToken, cookieOptions);

            return jwtToken;



        }


        public bool ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };

                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }

}
