using ApwPayroll_Application.Features.Employees.EmployeeExperiences.Commands.DeleteEmployeeExperience;
using ApwPayroll_Application.Features.Employees.EmployeeExperiences.Commands.UpdateEmployeeExperience;
using ApwPayroll_Application.Features.Employees.EmployeeExperiences.Queries.GetEmployeeExperiences;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees.EmployeeExperiences
{
    public class EmployeeExperienceController : BaseController
    {
        private readonly IMediator _mediator;

        public EmployeeExperienceController(IMediator mediator)
        {
            _mediator = mediator;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeExperience(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetInt32("EmployeeId") != null)
                {
                    model.Experiences.EmployeeId = HttpContext.Session.GetInt32("EmployeeId").Value;
                }
                if (model.Experiences.Id == 0 || model.Experiences.Id == null)
                {

                    var data = await _mediator.Send(model.Experiences);

                    if (data.code == 200)
                    {
                        Notify(data.Messages, null, data.code);
                    }
                    else
                    {
                        Notify(data.Messages, null, data.code);
                    }
                    return RedirectToAction("CreateEmployeeEducation", "EmployeeEducation");

                }
                else
                {
                    var data = await _mediator.Send(new UpdateEmployeeExperienceCommand(model.Experiences.Id.Value, model.Experiences));

                    if (data.code == 200)
                    {
                        Notify(data.Messages, null, data.code);
                    }
                    else
                    {
                        Notify(data.Messages, null, data.code);
                    }
                    model = new EmployeeCreateViewModel();
                    if (HttpContext.Session.GetInt32("EmployeeId") != null)
                    {

                        return View(model);
                    }
                    return RedirectToAction("EmployeeCompleteDetails", "Employee", new { id = data.Data.EmployeeId });
                }
            }
            return View();
        }

        public async Task<IActionResult> Update(int? id)
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            var data = await _mediator.Send(new GetEmployeeExperienceQuery(employeeId.Value));
            var getByIdExperience = data.Data.Find(x => x.Id == id);
            if (getByIdExperience == null)
            {
                return NotFound();
            }
            return RedirectToAction("CreateEmployeeEducation", "EmployeeEducation", new { id = getByIdExperience.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteEmployeeExperienceCommand(id));
            if (data.succeeded)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }
            return RedirectToAction("CreateEmployeeEducation", "EmployeeEducation");
        }
    }
}
