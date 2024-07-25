using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.CreateEmployeeDepartment;
using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.DeleteEmployeeDepartment;
using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.UpdateEmployeeDepartment;
using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Queries.GetAllEmployeeDepartment;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Masters.Departments
{
    public class DepartmentController : BaseController
    {

        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

         

        public async Task<IActionResult> DepartmentView(int? id)
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
            return View(model);
            }
            return  View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(EmployeeProfileModel employeeProfile)
        {
            
            if (employeeProfile.createDepartment.Id == 0 || employeeProfile.createDepartment.Id == null)
            {
                await _mediator.Send(employeeProfile.createDepartment);

            }
            else
            {
                await _mediator.Send(new UpdateEmployeeDepartmentCommand((int)employeeProfile.createDepartment.Id, employeeProfile.createDepartment));

                return View();
            }

            return RedirectToAction("DepartmentView");

        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteEmployeeDepartmentCommand(id));
            return RedirectToAction("DepartmentView");
        }

        private async Task IntializeViewBag()
        {
            var departmentList = await _mediator.Send(new GetAllEmployeeDepartmentQuery());
            if(departmentList.Data!=null&& departmentList.Data.Count != 0)
            {
             
            var employeeDepartment = departmentList.Data.ToList();
                 ViewBag.Department = employeeDepartment;
            

            }
        }

    }
}
