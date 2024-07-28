using ApwPayroll_Application.Features.Courses.Commands.UpdateStatus;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.CreateLeaveTypes;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.DeleteLeaveTypes;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.UpdateLeaveTypes;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.UpdateStatus;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Queries.GetAllLeaveTypes;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ApwPayrollWebApp.Controllers.Masters.Leaves.LeaveTypes
{
    public class LeaveTypeController : BaseController
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> LeaveTypeView(int? id)
        {
            await InitializeViewBag();
            var model = new MasterModel();
            if (id.HasValue && id != 0)
            {
                var leaveTypeData = await _mediator.Send(new GetAllLeaveTypeQuery());
                var leaveType = leaveTypeData.Data.FirstOrDefault(x => x.Id == id.Value);
                if (leaveType != null)
                {
                    model.createLeaveType = new CreateLeaveTypeCommand
                    {
                        Id = leaveType.Id,
                        Name = leaveType.Name,
                        IsActive = leaveType.IsActive,
                    };
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeaveType(MasterModel model)
        {
            if (model.createLeaveType.Id == 0 || model.createLeaveType.Id == null)
            {
                var data = await _mediator.Send(model.createLeaveType);
                Notify(data.Messages, null, data.code);
            }
            else
            {
                var data = await _mediator.Send(new UpdateLeaveTypeCommand((int)model.createLeaveType.Id, model.createLeaveType));
                Notify(data.Messages, null, data.code);
            }

            return RedirectToAction("LeaveTypeView");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, bool isActive)
        {
            var data = await _mediator.Send(new UpdateLeaveTypeStatus(id, isActive));
            Notify(data.Messages, null, data.code);
            return RedirectToAction("LeaveTypeView");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteLeaveTypeCommand(id));
            Notify(data.Messages, null, data.code);
            return RedirectToAction("LeaveTypeView");
        }

        private async Task InitializeViewBag()
        {
            var leaveTypeList = await _mediator.Send(new GetAllLeaveTypeQuery());
            if (leaveTypeList.Data != null && leaveTypeList.Data.Count != 0)
            {
                ViewBag.LeaveType = leaveTypeList.Data.ToList();
            }
        }
    }
}
