 
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.Commands.CreateEmployeeDocuments;
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Queries.GetAllEmployeeDomentTypes;
using ApwPayroll_Domain.Entities.Documents;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocuments;
using ApwPayroll_Persistence.Data;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using ApwPayrollWebApp.Views.Documents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees.EmployeeDocuments
{
    public class EmployeeDocumentController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDataContext _context;
        public EmployeeDocumentController(IMediator mediator, ApplicationDataContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            await InitializeViewBags();
          

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int EmployeeId, [FromForm]  EmployeeCreateViewModel  model)
        {
            if (HttpContext.Session.GetInt32("EmployeeId") != null)
            {
                EmployeeId = HttpContext.Session.GetInt32("EmployeeId").Value;
            }

            if (ModelState.IsValid)
            {
             var data=  await _mediator.Send(new CreateEmployeeDocumentCommand(EmployeeId,model.EmployeeDocument));
                if (data.code == 200)
                {
                    Notify(data.Messages, null, data.code);
                }
                else
                {
                    Notify(data.Messages, null, data.code);
                }
            }
            await InitializeViewBags();

            return View(model);
        }

    
        private async Task InitializeViewBags()
        {
            var employeeDocumentTypes = await _mediator.Send(new GetAllEmployeeDocumentTypesQuery());
            
            ViewBag.EmployeeDocumentTypes = employeeDocumentTypes.Data;
        }

    }
}

