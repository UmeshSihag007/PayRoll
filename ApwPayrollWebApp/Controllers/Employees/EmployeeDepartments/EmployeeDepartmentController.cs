using ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.CreateEmployeeCourses;
using ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.DeleteEmployeeCourses;
using ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.UpdateEmployeeCourses;
using ApwPayroll_Application.Features.Employees.EmployeeCouses.Queries.GetAllEmployeeCourses;
using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.CreateEmployeeDepartment;
using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.DeleteEmployeeDepartment;
using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.UpdateEmployeeDepartment;
using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Queries.GetAllEmployeeDepartment;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees.EmployeeDepartments
{
    public class EmployeeDepartmentController : BaseController
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
                var departmentData = await _mediator.Send(new GetAllEmployeeDepartmentQuery());
                var department = departmentData.Data.FirstOrDefault(x => x.Id == id.Value);
                if (department != null)
                {
                    model.createDepartment = new CreateEmployeeDepartmentCommand
                    {
                        Id = department.Id,
                        Name = department.Name,
                         Description = department.Description,
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
                await _mediator.Send(new CreateEmployeeDepartmentCommand());

            }
            else
            {
                await _mediator.Send(new UpdateEmployeeDepartmentCommand((int)employeeProfile.createCourses.Id, employeeProfile.createDepartment));
            }

            return RedirectToAction("Create");

        }
        public async Task<IActionResult> Update(int id)
        {

            var data = await _mediator.Send(new GetAllEmployeeDepartmentQuery());
            var departmetnDataById = data.Data.Find(x => x.Id == id);
            if (departmetnDataById == null)
            {
                return NotFound();
            }

            return RedirectToAction("Create", new { id = departmetnDataById.Id });
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteEmployeeDepartmentCommand(id));
            return RedirectToAction("Create");
        }

        private async Task IntializeViewBag()
        {
            var departmentList = await _mediator.Send(new GetAllEmployeeDepartmentQuery());
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            var employeeDepartment = departmentList.Data.ToList();
            if (employeeId != null)
            {

                ViewBag.Department = employeeDepartment;
            }
        }
    }
}
