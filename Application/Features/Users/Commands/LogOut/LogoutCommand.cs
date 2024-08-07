using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ApwPayroll_Application.Features.Users.Commands.LogOut
{
    public class LogoutCommand : IRequest<Result<int>>
    {
    }

    internal class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result<int>>
    {
        private readonly SignInManager<AspUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogoutCommandHandler(SignInManager<AspUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<int>> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
             

                await _signInManager.SignOutAsync();

                return Result<int>.Success(1);
            }
            catch (Exception ex)
            {
                return Result<int>.BadRequest("Logout failed. Please try again."); // Return a failure result
            }
        }
    }
}