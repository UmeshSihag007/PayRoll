using ApwPayroll_Application.Features.Employees.EmployeeDesignations.Commands.CreateEmployeeDesignation;
using ApwPayroll_Application.Features.Employees.EmployeeDesignations.Commands.DeleteEmployeeDesignation;
using ApwPayroll_Application.Features.Employees.EmployeeDesignations.Commands.UpdateEmployeeDesignation;
using ApwPayroll_Application.Features.Employees.EmployeeDesignations.Queries.GetAllEmployeeDesignation;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Masters.Designations
{
    public class DesignationController : BaseController
    {

        private readonly IMediator _mediator;

        public DesignationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> CreateDesignation(int? id)
        {
            await IntializeViewBag();
            var model = new EmployeeProfileModel();
            if (id.HasValue)
            {
                var designationData = await _mediator.Send(new GetAllEmployeeDesignationQuery());
                var designation = designationData.Data.FirstOrDefault(x => x.Id == id.Value);
                if (designation != null)
                {
                    model.createDesignation = new CreateEmployeeDesignationCommand
                    {
                        Id = designation.Id,
                        Name = designation.Name,
                        Description = designation.Description,
                    };
                }
                     
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDesignation(EmployeeProfileModel employeeProfile)
        {
             
            if (employeeProfile.createDesignation.Id == 0 || employeeProfile.createDesignation.Id == null)
            {
                await _mediator.Send(employeeProfile.createDesignation);

            }
            else
            {
                await _mediator.Send(new UpdateEmployeeDesignationCommand((int)employeeProfile.createDesignation.Id, employeeProfile.createDesignation));
            }

            return RedirectToAction("CreateDesignation");

        }
        public async Task<IActionResult> Update(int id)
        {

            var data = await _mediator.Send(new GetAllEmployeeDesignationQuery());
            var designationDataById = data.Data.Find(x => x.Id == id);
            if (designationDataById == null)
            {
                return NotFound();
            }

            return RedirectToAction("CreateDesignation", new { id = designationDataById.Id });
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteEmployeeDesignationCommand(id));
            return RedirectToAction("CreateDesignation");
        }

        private async Task IntializeViewBag()
        {
            var designationList = await _mediator.Send(new GetAllEmployeeDesignationQuery());
            if (designationList.Data != null && designationList.Data.Count != 0)
            {
            var employeeDesignation = designationList.Data.ToList();
            

                ViewBag.Designation = employeeDesignation;

            }
             
            
        }
    }
}
