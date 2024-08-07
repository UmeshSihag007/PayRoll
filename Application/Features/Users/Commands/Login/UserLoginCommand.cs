//using ApwPayroll_Application.Interfaces.Services;
//using ApwPayroll_Domain.Entities.AspUsers;
//using ApwPayroll_Shared;
//using AutoMapper;
//using MediatR;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using System.ComponentModel.DataAnnotations;
//using System.Security.Claims;

//namespace ApwPayroll_Application.Features.Users.Commands.Login
//{
//    public class UserLoginCommand : IRequest<Result<int>>
//    {
//        [Required]
//        [EmailAddress]
//        public string Email { get; set; }

//        [Required]
//        [DataType(DataType.Password)]
//        public string Password { get; set; }

//        [Display(Name = "Remember me?")]
//        public bool RememberMe { get; set; }
//    }

//    internal class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, Result<int>>
//    {
//        private readonly UserManager<AspUser> _userManager;
//        private readonly SignInManager<AspUser> _signInManager;
//        private readonly IJwtService _jwtService;
//        private readonly IMapper _mapper;
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public UserLoginCommandHandler(UserManager<AspUser> userManager, IMapper mapper, SignInManager<AspUser> signInManager, IJwtService jwtService, IHttpContextAccessor httpContextAccessor)
//        {
//            _userManager = userManager;
//            _mapper = mapper;
//            _signInManager = signInManager;
//            _jwtService = jwtService;
//            _httpContextAccessor = httpContextAccessor;
//        }

//        public async Task<Result<int>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
//        {
//            var user = await _userManager.FindByEmailAsync(request.Email);

//            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
//            {
//                // Creating identity
//                var claims = new List<Claim>
//                {
//                    new Claim(ClaimTypes.NameIdentifier, user.Id),
//                    new Claim(ClaimTypes.Name, user.UserName),
//                    // Add additional claims as needed
//                };

//                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

//                var httpContext = _httpContextAccessor.HttpContext;

//                if (httpContext != null)
//                {
//                    await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
//                    {
//                        IsPersistent = request.RememberMe, // Set RememberMe option if provided
//                        ExpiresUtc = DateTime.UtcNow.AddMinutes(30) // Set the cookie expiration if needed
//                    });
//                    await _jwtService.GenerateToken(user.Id);

//                    return Result<int>.Success(1, "Login success");
//                }
//                else
//                {
//                    return Result<int>.BadRequest("HttpContext is null");
//                }
//            }
//            else
//            {
//                return Result<int>.BadRequest("Invalid login attempt");
//            }
//        }
//    }
//}




using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Application.Interfaces.Services;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ApwPayroll_Application.Features.Users.Commands.Login
{
    public class UserLoginCommand : IRequest<Result<int>>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    internal class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, Result<int>>
    {
        private readonly UserManager<AspUser> _userManager;
        private readonly SignInManager<AspUser> _signInManager;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        public UserLoginCommandHandler(UserManager<AspUser> userManager, IMapper mapper, SignInManager<AspUser> signInManager, IJwtService jwtService, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            // Find user by email
            var user = await _userManager.FindByEmailAsync(request.Email);
           
            //var checkLoginAccess = await _unitOfWork.Repository<Employee>().Entities.Where(x => x.IsLoginAccess == true && x.IsDeleted == false && x.EmailId == request.Email).FirstOrDefaultAsync();
            //if (checkLoginAccess == null)
            //{
            //    return Result<int>.BadRequest("You have  no Access To Login");
            //}

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                // Sign in user
                var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, lockoutOnFailure: true);
                if (signInResult.Succeeded)
                {
                    // Get user roles and create claims
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(ClaimTypes.Name, user.UserName)
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                     

               
 
                        // Return success
                        return Result<int>.Success(1, "Login successful");
                 
                    
                }
                else
                {
                    return Result<int>.BadRequest("Invalid login attempt");
                }
            }
            
            
            else
            {
                return Result<int>.BadRequest("Invalid credentials");
            }
        }
    }
}
