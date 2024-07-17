using Amazon.Runtime.Internal.Auth;
using ApwPayroll_Application.Features.Menus.MenuTypes.Queries.GetMenuTypes;
using ApwPayroll_Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Menus.MenuTypes
{
    [Authorize]
    public class MenuTypeController : Controller
    {
        private readonly IMediator _mediator;

        public MenuTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task< IActionResult >Index()
        {
            var data = await _mediator.Send(new GetMenuTypeQuery());
            if(data == null ||data.Data.Count==0)
            {
                return View();
            }
            ViewBag.data=data;
            return View();
        } 
        public async Task< IActionResult>Create()
        {
            
            return View();
        }
    }
}
