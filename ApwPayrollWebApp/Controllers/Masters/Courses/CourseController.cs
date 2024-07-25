using ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.CreateEmployeeCourses;
using ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.DeleteEmployeeCourses;
using ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.UpdateEmployeeCourses;
using ApwPayroll_Application.Features.Employees.EmployeeCouses.Queries.GetAllEmployeeCourses;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Masters.Courses;

public class CourseController : BaseController
{

    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }


    public async Task<IActionResult> CourseView(int? id)
    {
        await IntializeViewBag();
        var model = new EmployeeProfileModel();
        if (id.HasValue && id != 0)
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
    public async Task<IActionResult> CreateCourse(EmployeeProfileModel employeeProfile)
    {

        if (employeeProfile.createCourses.Id == 0 || employeeProfile.createCourses.Id == null)
        {
            await _mediator.Send(employeeProfile.createCourses);

        }
        else
        {
            await _mediator.Send(new UpdateEmployeeCourseCommand((int)employeeProfile.createCourses.Id, employeeProfile.createCourses));



        }

        return RedirectToAction("CourseView");

    }
    [HttpPost]
    public IActionResult UpdateStatus(int id, bool isActive)
    {
        try
        {


            return Json(new { success = false });
        }
        catch (Exception ex)
        {
            // Log the exception
            return Json(new { success = false, message = ex.Message });
        }
    }


    public async Task<IActionResult> Delete(int id)
    {
        var data = await _mediator.Send(new DeleteEmployeeCourseCommand(id));
        return RedirectToAction("CreateCourse");
    }

    private async Task IntializeViewBag()
    {
        var courseList = await _mediator.Send(new GetEmployeeCoursesQuery());


        if (courseList.Data != null && courseList.Data.Count != 0)
        {
            var employeeCourse = courseList.Data.ToList();
            ViewBag.Course = employeeCourse;
        }



    }
}

