using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Holidays.HollidayTypes.Queries.GetAllHolidayTypes;

public class GetAllHolidayTypeQuery : IRequest<Result<List<HolidayType>>>
{
}
internal class GetAllHolidayTypeQueryHandler : IRequestHandler<GetAllHolidayTypeQuery, Result<List<HolidayType>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllHolidayTypeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Result<List<HolidayType>>> Handle(GetAllHolidayTypeQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<HolidayType>().GetAllAsync();
        var mapData = _mapper.Map<List<HolidayType>>(data);
        return Result<List<HolidayType>>.Success(mapData);
    }
}

