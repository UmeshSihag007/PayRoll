using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.DeleteHolidayTypes;

public class DeleteHolidayTypeCommand : IRequest<Result<HolidayType>>
{
    public DeleteHolidayTypeCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

}
internal class DeleteHolidayTypeCommandHandler : IRequestHandler<DeleteHolidayTypeCommand, Result<HolidayType>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHolidayTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<HolidayType>> Handle(DeleteHolidayTypeCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<HolidayType>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<HolidayType>.NotFound();
        }
        await _unitOfWork.Repository<HolidayType>().DeleteAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<HolidayType>.BadRequest("Deleted Successfully");

    }
}
