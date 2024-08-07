using ApwPayroll_Application.Features.Users.Commands.Login;
using ApwPayroll_Application.Features.Users.Commands.LogOut;
using ApwPayroll_Application.Features.Users.Commands.RegisterUsers;
using ApwPayrollWebApp.Controllers.Common;
using AspNetCoreHero.ToastNotification.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Users
{
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly INotyfService _notyf;
        public AccountController(IMediator mediator, INotyfService notyf)
        {
            _mediator = mediator;
            _notyf = notyf;
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserCommand userModel)
        {

            var data = await _mediator.Send(userModel);
          
            if (data.succeeded)
            {
                ViewBag.ErrorMessages = data.Messages;
                Notify(data.Messages, null, 200);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Notify(data.Messages, null, 400);
           return View(userModel);
            }
         
            
       
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginCommand userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var data = await _mediator.Send(userModel);
            if (data.succeeded && User != null )
            {
                Notify(data.Messages, null, data.code);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Notify(data.Messages, null, 400);
                ViewBag.ErrorMessages = data.Messages;
                return View(userModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            var data = await _mediator.Send(new LogoutCommand());
            if (data.succeeded == false)
            {
                return null;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
