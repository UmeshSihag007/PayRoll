//using ApwPayroll_Persistence.Data;
//using ApwPayrollWebApp.Views.Documents;
//using MediatR;

using ApwPayrollWebApp.Controllers.Common;

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace ApwPayrollWebApp.Controllers.Employees.EmployeeDocuments
//{
//    public class EmployeeDocumentController : Controller
//    {
//        private readonly  IMediator _mediator;
//        private readonly ApplicationDataContext _context;
//        public EmployeeDocumentController(IMediator mediator, ApplicationDataContext context)
//        {
//            _mediator = mediator;
//            _context = context;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }
//        public async Task<IActionResult> Create(int employeeId)
//        {
//            var documentTypes = await _context.DocumentTypes.ToListAsync();
//            var employee = await _context.Employees.FindAsync(employeeId);

//            var model = new DocumentViewModel
//            {
//                EmployeeId = employeeId,

//                DocumentTypes = documentTypes.Select(dt => new DocumentTypeViewModel
//                {
//                    DocumentTypeId = dt.Id,
//                    DocumentTypeName = dt.Name
//                }).ToList()
//            };

//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(DocumentViewModel model)

                var data = await _mediator.Send(new CreateEmployeeDocumentCommand(EmployeeId, model.EmployeeDocument));
                if (data.code == 200)
                {
                    Notify(data.Messages, null, data.code);
                }
                else
                {
                    Notify(data.Messages, null, data.code);
                }

//            if (ModelState.IsValid)
//            {
//                foreach (var docType in model.DocumentTypes)
//                {
//                    if (docType.File != null)
//                    {
//                        var document = new Document
//                        {
//                            Url = await SaveFile(docType.File),
//                            TypeId = docType.DocumentTypeId
//                        };
//                        _context.Documents.Add(document);
//                        await _context.SaveChangesAsync();

//                        var employeeDocument = new EmployeeDocument(document.Id, model.EmployeeId, true, docType.DocumentTypeId);
//                        _context.EmployeeDocuments.Add(employeeDocument);
//                    }
//                }

//                var employee = await _context.Employees.FindAsync(model.EmployeeId);
//                if (employee != null)
//                {

//                    _context.Update(employee);
//                }

//                await _context.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }

//            return View(model);
//        }

//        private async Task<string> SaveFile(IFormFile file)
//        {
//            var filePath = Path.Combine("wwwroot/uploads", Path.GetFileName(file.FileName));
//            using (var stream = new FileStream(filePath, FileMode.Create))
//            {
//                await file.CopyToAsync(stream);
//            }
//            return $"/uploads/{Path.GetFileName(file.FileName)}";
//        }
//    }
//}

using ApwPayroll_Application.Features.Employees.EmployeeDocuments.Commands.CreateEmployeeDocuments;
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Queries.GetAllEmployeeDomentTypes;
using ApwPayroll_Persistence.Data;
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
        public async Task<IActionResult> Create()
        {
            await InitializeViewBags();




            return View();
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
               await _mediator.Send(new CreateEmployeeDocumentCommand(EmployeeId,model.EmployeeDocument));
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

