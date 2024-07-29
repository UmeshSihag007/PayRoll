using ApwPayroll_Application.Features.Designations.Commands.CreateDesignation;
using ApwPayroll_Application.Features.Designations.Commands.DeleteDesignation;
using ApwPayroll_Application.Features.Designations.Commands.UpdateDesignation;
using ApwPayroll_Application.Features.Designations.Queries.GetAllDesignation;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Masters.Designations
{
    public class DesignationController : BaseController
    {

        private readonly IMediator _mediator;

        public DesignationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> DesignationView(int? id)
        {
            await IntializeViewBag();
            var model = new MasterModel();
            if (id.HasValue)
            {
                var designationData = await _mediator.Send(new GetAllDesignationQuery());
                var designation = designationData.Data.FirstOrDefault(x => x.Id == id.Value);
                if (designation != null)
                {
                    model.createDesignation = new CreateDesignationCommand
                    {
                        Id = designation.Id,
                        Name = designation.Name,
                        Description = designation.Description,
                    };
                }

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDesignation(MasterModel employeeProfile)
        {

            if (employeeProfile.createDesignation.Id == 0 || employeeProfile.createDesignation.Id == null)
            {
              var data=   await _mediator.Send(employeeProfile.createDesignation);
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
              var data=  await _mediator.Send(new UpdateDesignationCommand((int)employeeProfile.createDesignation.Id, employeeProfile.createDesignation));
                if (data.succeeded)
                {
                    Notify(data.Messages, null, data.code);
                }
                else
                {
                    Notify(data.Messages, null, data.code);
                }
            }

            return RedirectToAction("DesignationView");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteDesignationCommand(id));
            if (data.succeeded)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }
            return RedirectToAction("DesignationView");
        }

        private async Task IntializeViewBag()
        {
            var designationList = await _mediator.Send(new GetAllDesignationQuery());
            if (designationList.Data != null && designationList.Data.Count != 0)
            {
                var employeeDesignation = designationList.Data.ToList();
                ViewBag.Designation = employeeDesignation;

            }
        }
    }
}
