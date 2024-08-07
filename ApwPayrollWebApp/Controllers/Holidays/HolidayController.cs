

using ApwPayroll_Application.Features.Branches.Queries.GetAllBranches;
using ApwPayroll_Application.Features.Holidays.Commands.CreateHolidays;
using ApwPayroll_Application.Features.Holidays.Commands.UpdateHolidays;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Queries.GetAllHolidayTypes;
using ApwPayroll_Application.Features.Holidays.Queries.GetAllHolidays;
using ApwPayroll_Application.Features.Holidays.Queries.GetHolidayByIds;
using ApwPayroll_Application.Features.Locations.Queries.GetAllLocations;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.LocationTypes;
using ApwPayroll_Domain.Entities.Holidays;
using ApwPayroll_Shared;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.EnumHelpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApwPayrollWebApp.Controllers.Holidays;

public class HolidayController : BaseController
{
    private readonly IMediator _mediator;

    public HolidayController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _mediator.Send(new GetAllHolidayQuery());
        await InitializeViewBags();
        return View(data);
    }

    public async Task<IActionResult> CreateHoliday(int? id)
    {
        var model = new CreateHolidayCommand();
        if (id.HasValue)
        {
            var data = await _mediator.Send(new GetHolidayGetByIdQuery(id.Value));
            if (data.Data != null)
            {
                model = new CreateHolidayCommand
                {
                    Id = data.Data.Id,
                    Name = data.Data.Name,
                    ToDate = data.Data.ToDate,
                    FromDate = data.Data.FromDate,
                    Description = data.Data.Description,
                    HolidayTypeId = data.Data.HolidayTypeId,
                    IsNotifyToEmployee = data.Data.IsNotifyToEmployee,
                    IsResetToLeaveRequest = data.Data.IsResetToLeaveRequest,
                    HolidayRuleDto = new GetHolidayRuleDto
                    {
                        Gender = data.Data.HolidayTypeRules.Gender,
                        BranchId = data.Data.HolidayTypeRules.BranchId,
                      //  LocationId = data.Data.HolidayTypeRules.HolidayTypeRuleLocations.LocationId
                    }
                };
            }
        }
        await InitializeViewBags();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHoliday(CreateHolidayCommand command)
    {
        if (ModelState.IsValid)
        {
            Result<Holiday> result;
            if (command.Id == 0 || command.Id == null)
            {
                result = await _mediator.Send(command);
            }
            else
            {
                var updateCommand = new UpdateHolidayCommand(command.Id.Value, command);
                result = await _mediator.Send(updateCommand);
            }

            if (result.succeeded)
            {
                Notify(result.Messages, null, result.code);
                return RedirectToAction("Index");
            }
        }
        await InitializeViewBags();
        return View(command);
    }

 


    private async Task InitializeViewBags()
    {
        var types = await _mediator.Send(new GetAllHolidayTypeQuery());
        ViewBag.HolidayTypeList = types.Data ?? types.Data;

        var branches = await _mediator.Send(new GetAllBranchQuery());
        ViewBag.BranchList =branches.Data ?? branches.Data; ;

        var gender = EnumHelper.GetEnumValues<GenderEnum>().ToList();
        ViewBag.GenderList = gender;
    }
}




/*using ApwPayroll_Application.Features.Holidays.Commands.CreateHolidays;
using ApwPayroll_Application.Features.Holidays.Commands.UpdateHolidays;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Queries.GetAllHolidayTypes;
using ApwPayroll_Application.Features.Holidays.Queries.GetAllHolidays;
using ApwPayroll_Application.Features.Holidays.Queries.GetHolidayByIds;
using ApwPayroll_Domain.Entities.Holidays;
using ApwPayroll_Shared;
using ApwPayrollWebApp.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Holidays;

public class HolidayController : BaseController
{
    private readonly IMediator _mediator;

    public HolidayController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _mediator.Send(new GetAllHolidayQuery());
        await InitializeViewBags();
        return View(data);
    }

    public async Task<IActionResult> CreateHoliday(int? id)
    {
        var model = new CreateHolidayCommand();
        if (id.HasValue)
        {
            var data = await _mediator.Send(new GetHolidayGetByIdQuery(id.Value));
            if (data.Data != null)
            {
                model = new CreateHolidayCommand
                {
                    Id = data.Data.Id,
                    Name = data.Data.Name,
                    ToDate = data.Data.ToDate,
                    FromDate = data.Data.FromDate,
                    Description = data.Data.Description,
                    HolidayTypeId = data.Data.HolidayTypeId,
                    IsNotifyToEmployee = data.Data.IsNotifyToEmployee,
                    IsResetToLeaveRequest = data.Data.IsResetToLeaveRequest
                };
            }
        }
        await InitializeViewBags();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHoliday(CreateHolidayCommand command)
    {
        if (ModelState.IsValid)
        {
            Result<Holiday> result;
            if (command.Id == 0 || command.Id == null)
            {
                result = await _mediator.Send(command);
            }
            else
            {
                var updateCommand = new UpdateHolidayCommand(command.Id.Value, command);
                result = await _mediator.Send(updateCommand);
            }

            if (result.succeeded)
            {
                Notify(result.Messages, null, result.code);
                return RedirectToAction("Index");
            }
        }
        await InitializeViewBags();
        return View(command);
    }

    private async Task InitializeViewBags()
    {
        var type = await _mediator.Send(new GetAllHolidayTypeQuery());
        ViewBag.HolidayTypeList = type.Data;
    }
}
*/