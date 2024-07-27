using ApwPayroll_Application.Features.Locations.Commands.CreateLocations;
using ApwPayroll_Application.Features.Locations.Commands.DeleteLocations;
using ApwPayroll_Application.Features.Locations.Commands.UpdateLocations;
using ApwPayroll_Application.Features.Locations.Queries.GetAllLocations;
using ApwPayroll_Application.Features.Locations.Queries.GetLocationByIds;
using ApwPayroll_Domain.common.Enums.LocationTypes;
using ApwPayrollWebApp.Controllers.Common;
using ApwPayrollWebApp.EnumHelpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Locations
{
    public class LocationController : BaseController
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> LocationView(int? id)
        {
            await InitializeViewBag();
            var model = new CreateLcoationCommand();
            var locationType = EnumHelper.GetEnumValues<LocationTypeEnum>().ToList();
            ViewBag.LocationType = locationType;
            if (id.HasValue)
            {
                var data = await _mediator.Send(new GetLocationByIdQuery(id.Value));

                if (data.Data != null)
                {
                    model = new CreateLcoationCommand
                    {
                        Id = data.Data.Id,
                        LocationType = data.Data.LocationType,
                        Name = data.Data.Name,
                        ParentId = data.Data.ParentId,
                    };
                }
                return View(model);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLcoationCommand command)
        {
            if (command.Id.HasValue && command.Id.Value != 0)
            {
                await _mediator.Send(new UpdateLocationCommand(command.Id.Value, command));
            }
            else
            {
                await _mediator.Send(command);
            }

            return RedirectToAction("LocationView");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLocationCommand(id));
            return RedirectToAction("LocationView");
        }

        private async Task InitializeViewBag()
        {
            var locationResult = await _mediator.Send(new GetAllLocationQuery());

            if (locationResult != null && locationResult.Data != null)
            {
                ViewBag.LocationList = locationResult?.Data;
            }


        }
    }
}
