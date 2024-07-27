using ApwPayroll_Application.Features.Courses.Commands.UpdateStatus;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.CreateHolidayTypes;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.DeleteHolidayTypes;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.UpdateHolidayTypes;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.UpdateStatus;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Queries.GetAllHolidayTypes;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Masters.HolidayTypes;

public class HolidayTypeController : BaseController
{
    private readonly IMediator _mediator;

    public HolidayTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> HolidayTypeView(int? id)
    {
        await IntializeViewBag();
        var model = new MasterModel();
        if (id.HasValue && id != 0)
        {
            var holidayTypeData = await _mediator.Send(new GetAllHolidayTypeQuery());
            var holidayType = holidayTypeData.Data.FirstOrDefault(x => x.Id == id.Value);
            if (holidayType != null)
            {
                model.createHolidayType = new CreateHolidayTypeCommand
                {
                    Id = holidayType.Id,
                    Name = holidayType.Name,
                    IsActive = holidayType.IsActive
                };
            }
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHolidayType(MasterModel employeeProfile)
    {

        if (employeeProfile.createHolidayType.Id == 0 || employeeProfile.createHolidayType.Id == null)
        {
            await _mediator.Send(employeeProfile.createHolidayType);

        }
        else
        {
            await _mediator.Send(new UpdateHolidayTypeCommand((int)employeeProfile.createHolidayType.Id, employeeProfile.createHolidayType));
        }

        return RedirectToAction("HolidayTypeView");

    }
    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int id, bool isActive)
    {
        try
        {
            var data = await _mediator.Send(new UpdateHolidayTypeStatusCommand(id, isActive));
            if (data.succeeded)
            {
                Notify(data.Messages, null, data.code);

            }
            else
            {
                Notify(data.Messages, null, data.code);
            }

            return RedirectToAction("HolidayTypeView");


        }
        catch (Exception ex)
        {
            Notify(["Error"], null, 400);
            return RedirectToAction("HolidayTypeView");
        }

    }
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _mediator.Send(new DeleteHolidayTypeCommand(id));
        return RedirectToAction("HolidayTypeView");
    }

    private async Task IntializeViewBag()
    {
        var holidayTypeList = await _mediator.Send(new GetAllHolidayTypeQuery());
        if (holidayTypeList.Data != null && holidayTypeList.Data.Count != 0)
        {
            var data = holidayTypeList.Data.ToList();
            ViewBag.HolidayType = data;

        }

    }
}
