using ApwPayroll_Application.Interfaces.Services;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
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

        public UserLoginCommandHandler(UserManager<AspUser> userManager, IMapper mapper, SignInManager<AspUser> signInManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<Result<int>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
            
                await _signInManager.SignInAsync(user, request.RememberMe);
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                await _signInManager.Context.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));
                var token = await _jwtService.GenerateToken(user.Id);

                return Result<int>.Success(1, "login success", token);
            }
            else
            {
                return Result<int>.BadRequest("loginFiled");
            }
        }
    }
}
