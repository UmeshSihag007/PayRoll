using ApwPayroll_Application.Features.Courses.Commands.CreateCourses;
using ApwPayroll_Application.Features.Courses.Commands.DeleteCourses;
using ApwPayroll_Application.Features.Courses.Commands.UpdateCourses;
using ApwPayroll_Application.Features.Courses.Commands.UpdateStatus;
using ApwPayroll_Application.Features.Courses.Queries.GetAllCourses;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.UpdateLeaveTypesActive;
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
        var model = new MasterModel();
        if (id.HasValue && id != 0)
        {   
            var courseData = await _mediator.Send(new GetCoursesQuery());
            var course = courseData.Data.FirstOrDefault(x => x.Id == id.Value);
            if (course != null)
            {
                model.createCourses = new CreateCoursesCommand
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
    public async Task<IActionResult> CreateCourse(MasterModel employeeProfile)
    {

        if (employeeProfile.createCourses.Id == 0 || employeeProfile.createCourses.Id == null)
        {
          var data=  await _mediator.Send(employeeProfile.createCourses);
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
         var data=   await _mediator.Send(new UpdateCourseCommand((int)employeeProfile.createCourses.Id, employeeProfile.createCourses));
            if (data.succeeded)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }


        }

        return RedirectToAction("CourseView");

    }
    


    public async Task<IActionResult> Delete(int id)
    {
        var data = await _mediator.Send(new DeleteCourseCommand(id));

        if (data.succeeded)
        {
            Notify(data.Messages, null, data.code);
        }
        else
        {
            Notify(data.Messages, null, data.code);
        }

        return RedirectToAction("CourseView");
    }


    #region UPDATE  STATUS   
    [HttpPost]
    public async Task<IActionResult> UpdateIsActive(int id, bool isActive)
    {
        var data = await _mediator.Send(new UpdateCourseStatusCommand(id, isActive));
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


    private async Task IntializeViewBag()
    {
        var courseList = await _mediator.Send(new GetCoursesQuery());


        if (courseList.Data != null && courseList.Data.Count != 0)
        {
            var employeeCourse = courseList.Data.ToList();
            ViewBag.Course = employeeCourse;
        }



    }
}

