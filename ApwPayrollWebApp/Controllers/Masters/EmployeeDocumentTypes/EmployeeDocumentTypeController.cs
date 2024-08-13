using ApwPayroll_Application.Features.Courses.Commands.UpdateStatus;
using ApwPayroll_Application.Features.Designations.Commands.DeleteDesignation;
using ApwPayroll_Application.Features.DocumentTypes.Commands.CreateDocumentType;
using ApwPayroll_Application.Features.DocumentTypes.Commands.DeleteDocumentType;
using ApwPayroll_Application.Features.DocumentTypes.Commands.EditDocumentType;
using ApwPayroll_Application.Features.DocumentTypes.Queries.GetAllDocumentTypes;
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Commands.CreateEmployeeDocumentTypes;
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Commands.DeleteEmployeeDocumentTypes;
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Commands.UpdateEmployeeDocumenTypes;
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Commands.UpdateStatus;
using ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Queries.GetAllEmployeeDocumentTypes;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Masters.DocumentTypes
{
    public class EmployeeDocumentTypeController : BaseController
    {
        private readonly IMediator _mediator;

        public EmployeeDocumentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> EmployeeDocumentTypeView(int? id)
        {
            await IntializeViewBag();
            var model =  new MasterModel();
            if (id.HasValue)
            {
                var documentTypeData = await _mediator.Send(new GetAllEmployeeDocumentTypesQuery());
                var documentType= documentTypeData.Data.FirstOrDefault(x=>x.Id == id.Value);
                if(documentType != null) 
                {
                    model.documentType = new CreateEmployeeDocumentTypeCommand()
                    {
                        Id = documentType.Id,
                        Name = documentType.Name,
                        IsActive=documentType.IsActive,
                    };
                }
            }
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeDocumentType(MasterModel master)
        {
            if(master.documentType.Id==null|| master.documentType.Id == 0)
            {
                var data = await _mediator.Send(master.documentType);
                if (data.succeeded)
                {
                    Notify(data.Messages, null, data.code);
                }
                else
                {
                    Notify(data.Messages, null, data.code);
                }
            }
            else
            {
                var data = await _mediator.Send(new UpdateEmployeeDocumentTypeCommand((int)master.documentType.Id, master.documentType));
                if (data.succeeded)
                {
                    Notify(data.Messages, null, data.code);
                }
                else
                {
                    Notify(data.Messages, null, data.code);
                }
            }
            return RedirectToAction("EmployeeDocumentTypeView");
        }

        #region UPDATE  STATUS   
        [HttpPost]
        public async Task<IActionResult> UpdateIsActive(int id, bool isActive)
        {
            var data = await _mediator.Send(new UpdateEmployeeDocumentTypeStatusCommand(id, isActive));
            if (data.code == 200)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }

            return Json(new { success = true });
        }
        #endregion


        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteEmployeeDocumentTypeCommand(id));
            if (data.succeeded)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }
            return RedirectToAction("EmployeeDocumentTypeView");
        }
        private async Task IntializeViewBag()
        {
            var documentTypeList = await _mediator.Send(new GetAllEmployeeDocumentTypesQuery());
            if (documentTypeList.Data != null && documentTypeList.Data.Count != 0)
            {
                var documentType = documentTypeList.Data.ToList();
                ViewBag.EmployeeDocumentType = documentType;

            }
        }
    }
}
