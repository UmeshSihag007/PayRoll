using ApwPayroll_Application.Features.Departments.Commands.CreateDepartment;
using ApwPayroll_Application.Features.Departments.Commands.DeleteDepartment;
using ApwPayroll_Application.Features.Departments.Commands.UpdateDepartment;
using ApwPayroll_Application.Features.Departments.Queries.GetAllDepartment;
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
            var model = new MasterModel();
            if (id.HasValue)
            {
                var departmentData = await _mediator.Send(new GetAllDepartmentQuery());
                var department = departmentData.Data.FirstOrDefault(x => x.Id == id.Value);
                if (department != null)
                {
                    model.createDepartment = new CreateDepartmentCommand
                    {
                        Id = department.Id,
                        Name = department.Name,
                        Description = department.Description,
                    };
                }
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(MasterModel employeeProfile)
        {

            if (employeeProfile.createDepartment.Id == 0 || employeeProfile.createDepartment.Id == null)
            {
                await _mediator.Send(employeeProfile.createDepartment);

            }
            else
            {
                await _mediator.Send(new UpdateDepartmentCommand((int)employeeProfile.createDepartment.Id, employeeProfile.createDepartment));


            }

            return RedirectToAction("DepartmentView");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteDepartmentCommand(id));
            return RedirectToAction("DepartmentView");
        }

        private async Task IntializeViewBag()
        {
            var departmentList = await _mediator.Send(new GetAllDepartmentQuery());
            if (departmentList.Data != null && departmentList.Data.Count != 0)
            {

                var employeeDepartment = departmentList.Data.ToList();
                ViewBag.Department = employeeDepartment;


            }
        }

    }
}
