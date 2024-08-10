using ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.CreateHolidayTypes;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.DeleteHolidayTypes;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.UpdateHolidayTypes;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.UpdateStatus;
using ApwPayroll_Application.Features.Holidays.HollidayTypes.Queries.GetAllHolidayTypes;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Masters.HolidayTypes
{
    public class HolidayTypeController : BaseController
    {
        private readonly IMediator _mediator;

        public HolidayTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> HolidayTypeView(int? id)
        {
            await InitializeViewBag();
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
        public async Task<IActionResult> CreateHolidayType(MasterModel model)
        {
            if (model.createHolidayType.Id == 0 || model.createHolidayType.Id == null)
            {
                var data = await _mediator.Send(model.createHolidayType);
                Notify(data.Messages, null, data.code);
            }
            else
            {
                var data = await _mediator.Send(new UpdateHolidayTypeCommand((int)model.createHolidayType.Id, model.createHolidayType));
                Notify(data.Messages, null, data.code);
            }
            return RedirectToAction("HolidayTypeView");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, bool isActive)
        {
            var data = await _mediator.Send(new UpdateHolidayTypeStatusCommand(id, isActive));
            Notify(data.Messages, null, data.code);
            return RedirectToAction("HolidayTypeView");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteHolidayTypeCommand(id));
            Notify(data.Messages, null, data.code);
            return RedirectToAction("HolidayTypeView");
        }

        private async Task InitializeViewBag()
        {
            var holidayTypeList = await _mediator.Send(new GetAllHolidayTypeQuery());
            ViewBag.HolidayType = holidayTypeList?.Data?.ToList();
        }
    }
}
