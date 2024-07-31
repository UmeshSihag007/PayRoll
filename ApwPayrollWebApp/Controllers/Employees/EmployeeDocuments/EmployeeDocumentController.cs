using ApwPayroll_Application.Features.Employees.EmployeeDocuments.Commands.CreateEmployeeDocuments;
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Queries.GetAllEmployeeDocumentTypes;
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.Queries.GetDocumentById;
using ApwPayroll_Persistence.Data;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees.employee.EmployeeDocuments
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
        public async Task<IActionResult> Create(int? employeeId, int? id)
        {
            await InitializeViewBags();
            var model = new EmployeeCreateViewModel();
            if (id.HasValue)
            {
                var employee = HttpContext.Session.GetInt32("EmployeeId") ?? employeeId.Value;
                if (employee == default)
                {
                    return NotFound();
                }
                var document = await _mediator.Send(new GetDocumentByDocumentIdQuery(employee, id.Value));

                if (document != null)
                {
                    var employeeDocument = new CreateEmployeeDocumentDto
                    {
                        Code = document.Data.Code,
                        Document = (IFormFile)document.Data.Document,
                        EmployeeDocumentTypeId = document.Data.EmployeeDocumentTypeId,
                    };
                    model.documentCommand = new CreateEmployeeDocumentCommand
                    {
                        EmployeeId = document.Data.EmployeeId, 
                        EmployeeDocuments = new List<CreateEmployeeDocumentDto> { employeeDocument }
                    };
                }

            }



            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int EmployeeId, [FromForm] EmployeeCreateViewModel model)
        {
            if (HttpContext.Session.GetInt32("EmployeeId") != null)
            {
                EmployeeId = HttpContext.Session.GetInt32("EmployeeId").Value;
            }

            if (ModelState.IsValid)
            {
               
                    var data = await _mediator.Send(new CreateEmployeeDocumentCommand(EmployeeId, model.EmployeeDocument));
                    if (data.code == 200)
                    {
                        Notify(data.Messages, null, data.code);
                    }
                    else
                    {
                        Notify(data.Messages, null, data.code);
                    }

                    return RedirectToAction("ReferenceView", "EmployeeReferral");
 

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

