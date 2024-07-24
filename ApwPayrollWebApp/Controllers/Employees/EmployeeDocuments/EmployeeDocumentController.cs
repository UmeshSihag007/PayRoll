 

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
            //var model = new DocumentViewModel
            //{
            //    EmployeeId = employeeId,

            //    DocumentTypes = documentTypes.Select(dt => new DocumentTypeViewModel
            //    {
            //        DocumentTypeId = dt.Id,
            //        DocumentTypeName = dt.Name
            //    }).ToList()
            //};

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int EmployeeId, [FromForm]  EmployeeCreateViewModel  model)
        {
            if (ModelState.IsValid)
            {
               await _mediator.Send(new CreateEmployeeDocumentCommand(EmployeeId,model.EmployeeDocument));

                var data = await _mediator.Send(new CreateEmployeeDocumentCommand(EmployeeId, model.EmployeeDocument));
                if (data.code == 200)
                {
                    Notify(data.Messages, null, data.code);
                }
                else
                {
                    Notify(data.Messages, null, data.code);
                }

                return RedirectToAction("EmployeeReferral", "EmployeeReference");

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

