using ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.CreateEmployeeReferences;
using ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.DeleteEmployeeReferences;
using ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.UpdateEmployeeRerences;
using ApwPayroll_Application.Features.Employees.EmployeeReferences.Queries.GetAllEmployeeReferences;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Employees.EmployeeReferral
{
    public class EmployeeReferralController : BaseController
    {
        private readonly IMediator _mediator;

        public EmployeeReferralController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> ReferenceView(int? employeeId, int? id)
        {
            ViewBag.employeeId = employeeId;
            await IntializeViewBag();
            var model = new EmployeeCreateViewModel();
            if (id.HasValue)
            {
                var employee = HttpContext.Session.GetInt32("EmployeeId") ?? employeeId.Value;
                var referalData = await _mediator.Send(new GetEmployeeReferalQuery(employee));
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
            if (data.succeeded)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }
            return RedirectToAction("ReferenceView");
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeReference(EmployeeCreateViewModel command)
        {
            if (HttpContext.Session.GetInt32("EmployeeId") != null)
            {
                command.ReferencesCommand.EmployeeId = HttpContext.Session.GetInt32("EmployeeId").Value;
            }
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            if (employeeId != 0 && employeeId != null)
            {
                command.ReferencesCommand.EmployeeId = employeeId.Value;
            }

            if (command.ReferencesCommand.Id == 0 || command.ReferencesCommand.Id == null)
            {
                var data = await _mediator.Send(command.ReferencesCommand);
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
                    return RedirectToAction("ReferenceView");
                }
                return RedirectToAction("EmployeeCompleteDetails", "Employee", new { id = ViewBag.employeeId });
            }
            else
            {
                var data = await _mediator.Send(new UpdateEmployeeReferencesCommand((int)command.ReferencesCommand.Id, command.ReferencesCommand));
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
                    return RedirectToAction("ReferenceView");
                }
                return RedirectToAction("EmployeeCompleteDetails", "Employee", new { id = data.Data.EmployeeId });

            }

            return RedirectToAction("ReferenceView");

        }
        private async Task IntializeViewBag()
        {
            if (HttpContext.Session.GetInt32("EmployeeId") != 0 && HttpContext.Session.GetInt32("EmployeeId") != null)
            {
                var employeeId = HttpContext.Session.GetInt32("EmployeeId");

                var ReferralList = await _mediator.Send(new GetEmployeeReferalQuery(employeeId.Value));
                var employeeReferral = ReferralList.Data.Where(x => x.EmployeeId == employeeId).ToList();
                if (employeeId != null)
                {

                    ViewBag.Referral = employeeReferral;
                }

            }
        }



    }


}

