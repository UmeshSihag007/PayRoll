﻿using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.UpdateStatus;

public class UpdateHolidayTypeStatusCommand : IRequest<Result<HolidayType>>
{
    public UpdateHolidayTypeStatusCommand(int id, bool isActive)
    {
        Id = id;
        IsActive = isActive;
    }

    public int Id { get; set; }
    public bool IsActive { get; set; }
}

internal class UpdateHolidayTypeStatusCommandHandler : IRequestHandler<UpdateHolidayTypeStatusCommand, Result<HolidayType>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateHolidayTypeStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<HolidayType>> Handle(UpdateHolidayTypeStatusCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<HolidayType>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<HolidayType>.BadRequest("HolidayType not found.");
        }

        data.IsActive = request.IsActive;

        await _unitOfWork.Repository<HolidayType>().UpdateAsync(data);
        await _unitOfWork.Save(cancellationToken);

        return Result<HolidayType>.Success(data, "Update SuccessfullyS");
    }

}
