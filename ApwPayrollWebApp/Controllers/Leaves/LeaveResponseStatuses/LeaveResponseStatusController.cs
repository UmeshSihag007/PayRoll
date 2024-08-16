using ApwPayroll_Application.Features.Employees.Queries.GetEmployees;
using ApwPayroll_Application.Features.Leaves.LeaveResponseStatues.Commands.CreateLeaveResponseStatues;
using ApwPayroll_Application.Features.Leaves.LeaveResponseStatues.Commands.UpdateLeaveResponseStatues;
using ApwPayroll_Application.Features.Leaves.LeaveResponseStatues.Queries.GetLeaveResponseStatusByIds;
using ApwPayroll_Application.Features.Leaves.Queries.GetAllLeaves;
using ApwPayroll_Application.Features.Leaves.Queries.GetLeaveByIds;
using ApwPayroll_Domain.common.Enums.LeaveStatuses;
using ApwPayroll_Domain.Entities.Leaves.LeaveResponseStatues;
using ApwPayroll_Shared;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.EnumHelpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApwPayrollWebApp.Controllers.Leaves.LeaveResponseStatuses;

public class LeaveResponseStatusController : BaseController
{
    private readonly IMediator _mediator;

    public LeaveResponseStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _mediator.Send(new GetAllLeaveQuery());
        await InitializeViewBags();
        return View(data.Data);
    }

    public async Task<IActionResult> CreateLeaveStatus(int? id)
    {
        var model = new CreateLeaveResponeStatusCommand();
        if (id.HasValue)
        {
            var data = await _mediator.Send(new GetLeaveResponseStatusById(id.Value));
            if (data != null)
            {

                model = new CreateLeaveResponeStatusCommand
                {
                    Id = data.Id,
                    LeaveId = data.LeaveId,
                    ResponseById = data.ResponseById,
                    ResponseRemark = data.ResponseRemark,
                    LeaveStatus = data.LeaveStatus,
                    ResponseDate = DateTime.Now,
                    ForwordId = data.ForwordId,
                };
                HttpContext.Session.SetInt32("LeaveId", data.LeaveId);
            }
            var type = await _mediator.Send(new GetLeaveByIdQuery(data.LeaveId));
            ViewBag.LeaveType = type.Data;

        }
        await InitializeViewBags();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLeaveStatus(CreateLeaveResponeStatusCommand command)
    {


        if (ModelState.IsValid)
        {
            Result<LeaveResponseStatus> result;
            if (command.Id == 0 || command.Id == null)
            {
                command.LeaveStatus = LeaveStatusEnum.Pending;
                result = await _mediator.Send(command);
            }
            else
            {
                var LeaveId = HttpContext.Session.GetInt32("LeaveId");
                var updateCommand = new UpdateLeaveResponeStatusCommand(command.Id.Value, command, LeaveId);
                result = await _mediator.Send(updateCommand);
            }

            if (result.succeeded)
            {
                Notify(result.Messages, null, result.code);
                return RedirectToAction(nameof(Index));
            }
        }

        return View(command);
    }

    private async Task InitializeViewBags()
    {
        var leave = await _mediator.Send(new GetAllLeaveQuery());
        ViewBag.LeaveList = leave.Data;

        var leaveStatus = EnumHelper.GetEnumValues<LeaveStatusEnum>().ToList();
        ViewBag.LeaveStatusList = leaveStatus;

        var employee = await _mediator.Send(new GetEmployeeAllQuery());
        ViewBag.EMployeeList = employee.Data?.Select(b => new SelectListItem
        {
            Value = b.Id.ToString(),
            Text = b.FirstName + b.LastName,
        }).ToList() ?? new List<SelectListItem>();

    }

}
