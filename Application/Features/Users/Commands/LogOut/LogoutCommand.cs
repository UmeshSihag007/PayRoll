using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Shared;
using Couchbase.Management.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ApwPayroll_Application.Features.Users.Commands.LogOut
{
    public class LogoutCommand : IRequest<Result<int>>
    {
    }
    internal class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result<int>>
    {
        private readonly SignInManager<AspUser> _signInManager;

        public LogoutCommandHandler(SignInManager<AspUser> signInManager)
        {
            _signInManager = signInManager;
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
