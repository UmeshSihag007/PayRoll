using ApwPayroll_Application.Interfaces.Services;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApwPayroll_Application.Features.Users.Commands.RegisterUsers
{
    public class RegisterUserCommand : IRequest<Result<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AspUser> _userManager;
        private readonly IJwtService _jwtService;

        public RegisterUserCommandHandler(IMapper mapper, UserManager<AspUser> userManager, IJwtService jwtService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<Result<int>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AspUser>(request);
            user.Address = "pili mandori";
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return Result<int>.BadRequest(error.Description);
                }

            }
            await _userManager.AddToRoleAsync(user, "Admin");

            var token = await _jwtService.GenerateToken(user.Id);
            return Result<int>.Success(Convert.ToInt32(null), "Register successfully", token.ToString());
        }
    }
}
