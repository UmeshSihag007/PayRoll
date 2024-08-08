using ApwPayroll_Application.Features.Employees.Commands.UpdateIsLoginAccess;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.CreateLeaveTypes;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.DeleteLeaveTypes;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.UpdateLeaveTypes;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.UpdateLeaveTypesActive;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Queries.GetAllLeaveTypes;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Masters.Leaves.LeaveTypes;

public class LeaveTypeController : BaseController
{

    private readonly IMediator _mediator;

    public LeaveTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> LeaveTypeView(int? id)
    {
        await IntializeViewBag();
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
    public async Task<IActionResult> CreateLeaveType(MasterModel employeeProfile)
    {

        if (employeeProfile.createLeaveType.Id == 0 || employeeProfile.createLeaveType.Id == null)
        {
         var data=   await _mediator.Send(employeeProfile.createLeaveType);
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
            
           var data= await _mediator.Send(new UpdateLeaveTypeCommand((int)employeeProfile.createLeaveType.Id, employeeProfile.createLeaveType));
            if (data.succeeded)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }

        }

        return RedirectToAction("LeaveTypeView");

    }

    #region UPDATE  LOGIN ACCESS   
    [HttpPost]
    public async Task<IActionResult> UpdateIsActive(int id, bool isActive)
    {
        var data = await _mediator.Send(new UpdateLeaveTypeIsActiveCommand(id, isActive));
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

    public async Task<IActionResult> Delete(int id)
    {
        var data = await _mediator.Send(new DeleteLeaveTypeCommand(id));
        if (data.succeeded)
        {
            Notify(data.Messages, null, data.code);
        }
        else
        {
            Notify(data.Messages, null, data.code);
        }

        return RedirectToAction("LeaveTypeView");
    }

    private async Task IntializeViewBag()
    {
        var leaveTypeList = await _mediator.Send(new GetAllLeaveTypeQuery());


        if (leaveTypeList.Data != null && leaveTypeList.Data.Count != 0)
        {
            var leaveType = leaveTypeList.Data.ToList();
            ViewBag.LeaveType = leaveType;
        }
    }
}
