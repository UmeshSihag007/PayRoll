using ApwPayroll_Application.Features.Courses.Queries.GetAllCourses;
using ApwPayroll_Application.Features.Employees.EmployeeEducations.Commands.CreateEmployeeEducation;
using ApwPayroll_Application.Features.Employees.EmployeeEducations.Commands.DeleteEmployeeEducation;
using ApwPayroll_Application.Features.Employees.EmployeeEducations.Quories.GetAllEmployeeQualifications;
using ApwPayroll_Application.Features.Employees.EmployeeExperiences.Commands.CreateEmployeeExperiences;
using ApwPayroll_Application.Features.Employees.EmployeeExperiences.Queries.GetEmployeeExperiences;
using ApwPayroll_Application.Features.Employees.EmployeeQualifications.Commands.UpdateEmployeeQualification;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees.EmployeeEducations
{
    public class EmployeeEducationController : BaseController
    {
        private readonly IMediator _mediator;
        public EmployeeEducationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateEmployeeEducation(int? employeeId, int? id)
        {
            ViewBag.employeeId = employeeId;
     
            await InitializeViewBags();
 
            var model = new EmployeeCreateViewModel();
 
            if (id.HasValue)
            { 

                var employee = HttpContext.Session.GetInt32("EmployeeId") ?? employeeId.Value;
 
                if (employee == default)
                {
                     
                    return NotFound();      
                }
                 
                var employeeEducationData = await _mediator.Send(new GetEmployeeQualificationQuery(employee));
                var employeeExperienceData = await _mediator.Send(new GetEmployeeExperienceQuery(employee));
 
                var qualification = employeeEducationData.Data.FirstOrDefault(x => x.Id == id.Value);
                var experience = employeeExperienceData.Data.FirstOrDefault(x => x.Id == id.Value);
 
                if (qualification != null)
                {
                    model.Qualification = new CreateEmployeeEducationCommand
                    {
                        Id = qualification.Id,
                        EmployeeId= qualification.EmployeeId,
                        Specification = qualification.Specification,
                        CourseId = qualification.CourseId,
                        ObtainMarks = qualification.ObtainMarks,
                        TotalMarks = qualification.TotalMarks,
                        ToDate = qualification.ToDate,
                        FromDate = qualification.FromDate,
                        UniversityBoard = qualification.UniversityBoard,
                    };
                }

                // Populate the view model with the experience data if found
                if (experience != null)
                {
                    model.Experiences = new CreateEmployeeExperiencesCommand
                    {
                        Id = experience.Id,
                        EmployeeId = experience.EmployeeId,
                        AnnualInCome = experience.AnnualInCome,
                        ComanyAddress = experience.ComanyAddress,
                        ComanyName = experience.ComanyName,
                        CompletedDate = experience.CompletedDate,
                        Designation = experience.Designation,
                        EmployeeCode = experience.EmployeeCode,
                        InsuranceNumber = experience.InsuranceNumber,
                        StartDate = experience.StartDate,
                        Industry = experience.Industry,
                    };
                }
            }

            // Return the view with the populated model
            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> CreateEmployeeEducation(EmployeeCreateViewModel commond)
        {
            await InitializeViewBags();
            if (HttpContext.Session.GetInt32("EmployeeId") != null)
            {
                commond.Qualification.EmployeeId = HttpContext.Session.GetInt32("EmployeeId").Value;
            }

            if (ModelState.IsValid)
            {

                if (commond.Qualification.Id == 0 || commond.Qualification.Id == null)
                {
                    
                    var data = await _mediator.Send(commond.Qualification);
                    if (data.code == 200)
                    {
                        Notify(data.Messages, null, data.code);
                    }
                    else
                    {
                        Notify(data.Messages, null, data.code);
                    }
                    if (HttpContext.Session.GetInt32("EmployeeId") != null)
                    {

                        return View(commond);
                    }
                    return RedirectToAction("EmployeeCompleteDetails", "Employee", new { id = ViewBag.employeeId });
                }
                else
                {
                    var data = await _mediator.Send(new UpdateEmployeeQualificationCommand((int)commond.Qualification.Id, commond.Qualification));
                    //  var data = await _mediator.Send(commond.Qualification);
                  
                    if (data.code == 200)
                    {
                        Notify(data.Messages, null, data.code);
                    }
                    else
                    {
                        Notify(data.Messages, null, data.code);
                    }
                    commond = new EmployeeCreateViewModel();
                    if (HttpContext.Session.GetInt32("EmployeeId") != null)
                    {

                    return View(commond);
                    }
                    return RedirectToAction("EmployeeCompleteDetails", "Employee", new { id = data.Data.EmployeeId });
                }
            }


            Notify(["Internal Error"], null, 400);
            return RedirectToAction("CreateEmployeeEducation");
        }


        public async Task<IActionResult> Update(int id)
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId").Value;


            var data = await _mediator.Send(new GetEmployeeQualificationQuery(employeeId));


            var QaulificationDataById = data.Data.Find(x => x.Id == id);
            if (QaulificationDataById == null)
            {
                return NotFound();
            }
            if (data.code == 200)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }

            HttpContext.Session.SetInt32("EmployeeId", employeeId);

            return RedirectToAction("CreateEmployeeEducation", new { id = QaulificationDataById.Id });
        }





        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteEmployeeEducationCommand(id));
            if (data.succeeded)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }
            return RedirectToAction("CreateEmployeeEducation");
        }
        private async Task InitializeViewBags()
        {


            var course = await _mediator.Send(new GetCoursesQuery());

            if (HttpContext.Session.GetInt32("EmployeeId") != 0 && HttpContext.Session.GetInt32("EmployeeId") != null)

            {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
                var employeeEducationData = await _mediator.Send(new GetEmployeeQualificationQuery(employeeId.Value));
                var employeeExperienceData = await _mediator.Send(new GetEmployeeExperienceQuery(employeeId.Value));

                ViewBag.ExperienceList = employeeExperienceData.Data;
                ViewBag.QualificationList = employeeEducationData.Data;

            }
            ViewBag.Course = course.Data;
            ViewBag.Years = GetYearsList(1980, DateTime.Now.Year);
        }

        private List<int> GetYearsList(int startYear, int endYear)
        {
            var years = new List<int>();
            for (int year = startYear; year <= endYear; year++)
            {
                years.Add(year);
            }
            return years;
        }
    }
}
