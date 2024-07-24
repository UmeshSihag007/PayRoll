using ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.CreateEmployeeCourses;
using ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.DeleteEmployeeCourses;
using ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.UpdateEmployeeCourses;
using ApwPayroll_Application.Features.Employees.EmployeeCouses.Queries.GetAllEmployeeCourses;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees.EmployeeCourses
{
    public class EmployeeCourseController : BaseController
    {
        private readonly IMediator _mediator;

        public EmployeeCourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
                var courseData = await _mediator.Send(new GetEmployeeCoursesQuery());
                var course = courseData.Data.FirstOrDefault(x => x.Id == id.Value);
                if (course != null)
                {
                    model.createCourses = new CreateEmployeeCoursesCommand
                    {
                        Id = course.Id,
                        Name = course.Name,
                        IsActive = course.IsActive,
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
                await _mediator.Send(new CreateEmployeeCoursesCommand());

            }
            else
            {
                await _mediator.Send(new UpdateEmployeeCourseCommand((int)employeeProfile.createCourses.Id, employeeProfile.createCourses));
            }

            return RedirectToAction("Create");

        }
        public async Task<IActionResult> Update(int id)
        {

            var data = await _mediator.Send(new GetEmployeeCoursesQuery());
            var courseDataById = data.Data.Find(x => x.Id == id);
            if (courseDataById == null)
            {
                return NotFound();
            }

            return RedirectToAction("Create", new { id = courseDataById.Id });
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteEmployeeCourseCommand(id));
            return RedirectToAction("Create");
        }

        private async Task IntializeViewBag()
        {
            var courseList = await _mediator.Send(new GetEmployeeCoursesQuery());
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            var employeeCourse = courseList.Data.ToList();
            if (employeeId != null)
            {

                ViewBag.Course = employeeCourse;
            }
        }
    }
}


