using ApwPayroll_Application.Features.Branches.Queries.GetAllBranches;
using ApwPayroll_Application.Features.Designations.Queries.GetAllDesignation;
using ApwPayroll_Application.Features.Leaves.Commands.CreateLeaves;
using ApwPayroll_Application.Features.Leaves.Commands.UpdateLeaves;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Queries.GetAllLeaveTypes;
using ApwPayroll_Application.Features.Leaves.Queries.GetAllLeaves;
using ApwPayroll_Application.Features.Leaves.Queries.GetLeaveByIds;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.LeaveStatuses;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypeRoles;
using ApwPayroll_Shared;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.EnumHelpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApwPayrollWebApp.Controllers.Leaves;

public class LeaveController : BaseController
{
    private readonly IMediator _mediator;

    public LeaveController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _mediator.Send(new GetAllLeaveQuery());
        await InitializeViewBags();
        return View(data.Data);
    }

    public async Task<IActionResult> CreateLeave(int? id)
    {
        var model = new CreateLeaveCommand();
        if (id.HasValue)
        {
            var data = await _mediator.Send(new GetLeaveByIdQuery(id.Value));
            if (data.Data != null)
            {
               var rule = data.Data.LeaveType.LeaveTypeRole.FirstOrDefault();

                model = new CreateLeaveCommand
                {
                    Id = data.Data.Id,
                    LeaveTypeId = data.Data.LeaveTypeId,
                    Reason = data.Data.Reason,
                    ToDate=data.Data.ToDate,
                    FromDate=data.Data.FromDate,
                    ContactNumber = data.Data.ContactNumber,
                    IsPaid = data.Data.IsPaid,
                    LeaveStatus = data.Data.LeaveStatus,
                    IsHalfDay = data.Data.IsHalfDay,

                    LeaveTypeRole = data.Data.LeaveType.LeaveTypeRole!= null ? new LeaveTypeRule
                    {
                        BranchId = rule?.BranchId?? 0,
                        DesignationId = rule?.DesignationId ?? 0,
                        Gender = rule?.Gender,
                    } : null
                };
            }
           var type = await _mediator.Send(new GetLeaveByIdQuery(data.Data.LeaveTypeId));
            ViewBag.LeaveType = type.Data;
        }
        await InitializeViewBags();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLeave(CreateLeaveCommand command)
    {
       
        if (ModelState.IsValid)
        {
            Result<Leave> result;
            if (command.Id == 0 || command.Id == null)
            {
                command.LeaveStatus = LeaveStatusEnum.Pending;
                result = await _mediator.Send(command);
            }
            else
            {
                var updateCommand = new UpdateLeaveCommand(command.Id.Value, command);
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
        var leaveTypes = await _mediator.Send(new GetAllLeaveTypeQuery());
        ViewBag.LeaveTypeList = leaveTypes.Data?.Select(l => new SelectListItem
        {
            Value = l.Id.ToString(),
            Text = l.Name
        }).ToList() ?? new List<SelectListItem>(); // Default to empty list if null

        var gender = EnumHelper.GetEnumValues<GenderEnum>().ToList();
        ViewBag.GenderList = gender;

        var branches = await _mediator.Send(new GetAllBranchQuery());
        ViewBag.BranchList = branches.Data?.Select(b => new SelectListItem
        {
            Value = b.Id.ToString(),
            Text = b.Name
        }).ToList() ?? new List<SelectListItem>(); // Default to empty list if null

        var designations = await _mediator.Send(new GetAllDesignationQuery());
        ViewBag.DesignationList = designations.Data?.Select(d => new SelectListItem
        {
            Value = d.Id.ToString(),
            Text = d.Name
        }).ToList() ?? new List<SelectListItem>(); // Default to empty list if null
    }


}
