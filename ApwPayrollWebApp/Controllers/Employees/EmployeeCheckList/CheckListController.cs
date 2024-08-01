using ApwPayroll_Application.Features.Employees.Queries.GetByIdEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees.EmployeeCheckList
{
    public class CheckListController : Controller
    {
        private readonly IMediator _mediator;

        public CheckListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            //var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            var employeeId = 83;
            if (employeeId != 0 && employeeId != null)
            {
                var data = await _mediator.Send(new GetEmployeeByIdQuery(employeeId));
                var firstDesignation = data.Data.EmployeeDesignations.First().Designation;
                var firstDepartment = data.Data.EmployeeDepartments.First().Department;
                ViewBag.department = firstDepartment;
                ViewBag.designation=firstDesignation;   
                ViewBag.employee = data.Data;
            }
            return View();
        }

    }
}
