using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.CreateEmployeeDepartment;
using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.DeleteEmployeeDepartment;
using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.UpdateEmployeeDepartment;
using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Queries.GetAllEmployeeDepartment;
using ApwPayroll_Application.Features.Employees.EmployeeDesignations.Commands.CreateEmployeeDesignation;
using ApwPayroll_Application.Features.Employees.EmployeeDesignations.Commands.DeleteEmployeeDesignation;
using ApwPayroll_Application.Features.Employees.EmployeeDesignations.Commands.UpdateEmployeeDesignation;
using ApwPayroll_Application.Features.Employees.EmployeeDesignations.Queries.GetAllEmployeeDesignation;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees.EmployeeDesignations
{
    public class EmployeeDesignationController : BaseController
    {
        private readonly IMediator _mediator;
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(int? id)
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
        public async Task<IActionResult> Create(EmployeeProfileModel employeeProfile)
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId").Value;
            if (HttpContext.Session.GetInt32("EmployeeId") != null)
            {
                employeeId = HttpContext.Session.GetInt32("employeeId").Value;
            }
            if (employeeProfile.createCourses.Id == 0 || employeeProfile.createCourses.Id == null)
            {
                await _mediator.Send(new CreateEmployeeDesignationCommand());

            }
            else
            {
                await _mediator.Send(new UpdateEmployeeDesignationCommand((int)employeeProfile.createCourses.Id, employeeProfile.createDesignation));
            }

            return RedirectToAction("Create");

        }
        public async Task<IActionResult> Update(int id)
        {

            var data = await _mediator.Send(new GetAllEmployeeDesignationQuery());
            var designationDataById = data.Data.Find(x => x.Id == id);
            if (designationDataById == null)
            {
                return NotFound();
            }

            return RedirectToAction("Create", new { id = designationDataById.Id });
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteEmployeeDesignationCommand(id));
            return RedirectToAction("Create");
        }

        private async Task IntializeViewBag()
        {
            var designationList = await _mediator.Send(new GetAllEmployeeDesignationQuery());
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            var employeeDesignation = designationList.Data.ToList();
            if (employeeId != null)
            {

                ViewBag.Designation = employeeDesignation;
            }
        }
    }
}
