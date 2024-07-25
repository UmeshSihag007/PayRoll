using ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.CreateEmployeeReferences;
using ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.DeleteEmployeeReferences;
using ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.UpdateEmployeeRerences;
using ApwPayroll_Application.Features.Employees.EmployeeReferences.Queries.GetAllEmployeeReferences;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees.EmployeeReferral
{
    public class EmployeeReferralController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeReferralController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> ReferenceView(int? id)
        {
            await IntializeViewBag();
            var model = new EmployeeCreateViewModel();
            if (id.HasValue)
            {
                var referalData = await _mediator.Send(new GetEmployeeReferalQuery());
                var refer = referalData.Data.FirstOrDefault(x => x.Id == id.Value);
                if (refer != null)
                {
                    model.ReferencesCommand = new CreateEmployeeReferencesCommand
                    {
                        Id = refer.Id,
                        ReferenceName = refer.ReferenceName,
                        Designation = refer.Designation,
                        OrganizationName = refer.OrganizationName,
                        ContactNumber = refer.ContactNumber,
                        YearsOfAcquaintance = refer.YearsOfAcquaintance
                    };

                }
            }
          
            return View(model);
        }

       

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteEmployeeReferenceCommand(id));
            return RedirectToAction("ReferenceView");
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeReference(EmployeeCreateViewModel command)
        {

            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            if (employeeId != 0 && employeeId != null)
            {
                command.ReferencesCommand.EmployeeId = employeeId.Value;
            }
             
            if (command.ReferencesCommand.Id == 0 || command.ReferencesCommand.Id == null)
            {
                await _mediator.Send(command.ReferencesCommand);
            }
            else
            {
                await _mediator.Send(new UpdateEmployeeReferencesCommand((int)command.ReferencesCommand.Id, command.ReferencesCommand));
            }

            return RedirectToAction("ReferenceView");

        }
        private async Task IntializeViewBag()
        {
            var ReferralList = await _mediator.Send(new GetEmployeeReferalQuery());
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
           var employeeReferral=  ReferralList.Data.Where(x=>x.EmployeeId== employeeId).ToList();
            if (employeeId != null)
            {

                ViewBag.Referral = employeeReferral;
            }
        }



    }


}

