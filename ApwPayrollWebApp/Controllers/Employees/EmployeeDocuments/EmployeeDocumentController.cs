using ApwPayroll_Application.Features.Employees.Commands.CreateEmployee;
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.Commands.CreateEmployeeDocuments;
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Queries.GetAllEmployeeDocumentTypes;
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.Queries.GetDocumentById;
using ApwPayroll_Persistence.Data;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using ApwPayrollWebApp.SessionManagement;
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
            ViewBag.EmployeeId = employeeId;
            await InitializeViewBags();


            var model = new EmployeeCreateViewModel();
            if (id != null && employeeId != null)
            {
                var employee = HttpContext.Session.GetInt32("EmployeeId") ?? employeeId.Value;
                if (employee == default)
                {
                    return NotFound();
                }

                var document = await _mediator.Send(new GetDocumentByDocumentIdQuery(employee, id.Value));
                if (document.Data.Document != null)
                {

                    ViewBag.document = document.Data?.Document.Url;
                }
                ViewBag.EmployeeDocumentType = document.Data.EmployeeDocumentType.Name;
                ViewBag.EmployeeDocumentTypeId = document.Data.EmployeeDocumentType.Id;
                if (document != null)
                {
                    var employeeDocument = new CreateEmployeeDocumentDto
                    {
                        Code = document.Data.Code,
                        EmployeeDocumentTypeId = document.Data.EmployeeDocumentTypeId,
                        IsCodeRequired = document.Data.EmployeeDocumentType.IsCodeRequired,
                        IsDocumentRequired = document.Data.EmployeeDocumentType.IsDocumentRequired,

                    };
                    model.documentCommand = new CreateEmployeeDocumentCommand
                    {
                        EmployeeId = document.Data.EmployeeId,
                        EmployeeDocuments = new List<CreateEmployeeDocumentDto> { employeeDocument }
                    };


                    model.EmployeeDocument = new List<CreateEmployeeDocumentDto>
                    {
                        employeeDocument
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
            ModelState.Remove("EmployeeId");

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
                    await InitializeViewBags();

                    return View(model);
                }
                if (HttpContext.Session.GetInt32("EmployeeId") != null)
                {
                    return RedirectToAction("ReferenceView", "EmployeeReferral");

                }
                return RedirectToAction("EmployeeCompleteDetails", "Employee", new { id = EmployeeId });



            }
            await InitializeViewBags();

            return View(model);
        }



        public async Task<IActionResult> DownloadFile(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();
                }

                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                var fileName = Path.GetFileName(url);

                return File(fileBytes, "application/pdf", fileName);
            }
        }

        private async Task InitializeViewBags()
        {
            var employeeDocumentTypes = await _mediator.Send(new GetAllEmployeeDocumentTypesQuery());


            ViewBag.EmployeeDocumentTypes = employeeDocumentTypes.Data.Where(x => x.IsActive == true).ToList();
        }

    }
}

