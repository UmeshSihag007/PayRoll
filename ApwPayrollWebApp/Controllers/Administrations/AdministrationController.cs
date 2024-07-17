using ApwPayroll_Application.Features.Users.Commands.Login;
using ApwPayroll_Application.Features.Users.Commands.LogOut;
using ApwPayroll_Application.Features.Users.Commands.RegisterUsers;
using AspNetCoreHero.ToastNotification.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Users
{
    public class AdministrationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly INotyfService _notyf;
        public AdministrationController(IMediator mediator, INotyfService notyf)
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
            if (data.succeeded == false)
            {
                ViewBag.ErrorMessages = data.Messages;
                foreach (var message in data.Messages)
                {
                    _notyf.Error(message);
                }
                return View(userModel);
            }
            foreach (var message in data.Messages)
            {
                _notyf.Success(message);
            }
            return RedirectToAction("Index", "Home");
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
            if (data.succeeded && User != null && User.Identity.IsAuthenticated)
            {
                foreach (var message in data.Messages)
                {
                    _notyf.Success(message);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var message in data.Messages)
                {
                    _notyf.Error(message);
                }
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
