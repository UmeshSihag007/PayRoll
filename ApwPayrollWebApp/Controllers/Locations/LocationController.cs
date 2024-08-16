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
            var model = new CreateLocationCommand();
            var locationType = EnumHelper.GetEnumValues<LocationTypeEnum>().ToList();
            ViewBag.LocationType = locationType;
            if (id.HasValue)
            {
                var data = await _mediator.Send(new GetLocationByIdQuery(id.Value));

                if (data.Data != null)
                {
                    model = new CreateLocationCommand
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
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            if (command.Id.HasValue && command.Id.Value != 0)
            {
                var data = await _mediator.Send(new UpdateLocationCommand(command.Id.Value, command));
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
                var data = await _mediator.Send(command);
                if (data.succeeded)
                {
                    Notify(data.Messages, null, data.code);
                }
                else
                {
                    Notify(data.Messages, null, data.code);
                }

            }

            return RedirectToAction("LocationView");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteLocationCommand(id));
            if (data.succeeded)
            {
                Notify(data.Messages, null, data.code);
            }
            else
            {
                Notify(data.Messages, null, data.code);
            }
            return RedirectToAction("LocationView");
        }


        public async Task<IActionResult> GetStatesByCountry( )
        {
            var locations = await _mediator.Send(new GetAllLocationQuery());
            var states = locations.Data
                .Where(x => x.LocationType == LocationTypeEnum.State && x.ParentId == 1)

                .ToList();
            return Json(states);
        }

        [HttpGet]
        public async Task<IActionResult> GetCitiesByState()
        {
            var locations = await _mediator.Send(new GetAllLocationQuery());
            var cities = locations.Data
                .Where(x => x.LocationType == LocationTypeEnum.City && x.ParentId == 2)

                .ToList();
            return Json(cities);
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
