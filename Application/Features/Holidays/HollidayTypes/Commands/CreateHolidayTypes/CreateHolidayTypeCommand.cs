using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Holidays.HollidayTypes.Commands.CreateHolidayTypes;

public class CreateHolidayTypeCommand : IRequest<Result<int>>
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
internal class CreateHolidayTypeCommandHandler : IRequestHandler<CreateHolidayTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateHolidayTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateHolidayTypeCommand request, CancellationToken cancellationToken)
    {
        var mapData = _mapper.Map<HolidayType>(request);
        await _unitOfWork.Repository<HolidayType>().AddAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();
    }


}
