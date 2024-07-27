using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.DeleteHolidayTypes;

public class DeleteHolidayTypeCommand : IRequest<Result<int>>
{
    public DeleteHolidayTypeCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

}
internal class DeleteHolidayTypeCommandHandler : IRequestHandler<DeleteHolidayTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHolidayTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteHolidayTypeCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<HolidayType>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.NotFound();
        }
        await _unitOfWork.Repository<HolidayType>().DeleteAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();

    }
}
