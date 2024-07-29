using ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.CreateHolidayTypes;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.UpdateHolidayTypes;

public class UpdateHolidayTypeCommand : IRequest<Result<HolidayType>>
{
    public UpdateHolidayTypeCommand(int id, CreateHolidayTypeCommand command)
    {
        Id = id;    
        this.command = command;
    }

    public int Id { get; set; }
    public CreateHolidayTypeCommand command { get; set; }

}
internal class UpdateHolidayTypeCommandHandler : IRequestHandler<UpdateHolidayTypeCommand, Result<HolidayType>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateHolidayTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<HolidayType>> Handle(UpdateHolidayTypeCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<HolidayType>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<HolidayType>.BadRequest();
        }

        var mapData = _mapper.Map(request.command, data);
        await _unitOfWork.Repository<HolidayType>().UpdateAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<HolidayType>.Success(data, "Update Successfully");
    }
}
