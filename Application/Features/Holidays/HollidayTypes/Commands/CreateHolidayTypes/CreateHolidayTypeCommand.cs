using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.CreateHolidayTypes;

public class CreateHolidayTypeCommand : IRequest<Result<HolidayType>>
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
internal class CreateHolidayTypeCommandHandler : IRequestHandler<CreateHolidayTypeCommand, Result<HolidayType>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateHolidayTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<HolidayType>> Handle(CreateHolidayTypeCommand request, CancellationToken cancellationToken)
    {
        var mapData = _mapper.Map<HolidayType>(request);
       var data= await _unitOfWork.Repository<HolidayType>().AddAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<HolidayType>.Success(data,"Created Successfully");
    }


}
