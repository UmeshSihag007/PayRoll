using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Holidays;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Holidays.Commands.CreateHolidays;

public class CreateHolidayCommand : IRequest<Result<Holiday>>
{
    public int? Id {  get; set; }
    public string Name { get; set; }
    public DateTime ToDate { get; set; }
    public DateTime FromDate { get; set; }
    public bool IsNotifyToEmployee { get; set; }
    public bool IsResetToLeaveRequest { get; set; }
    public string Description { get; set; }
    public int HolidayTypeId { get; set; }
}
internal class CreateHolidayCommandHandler : IRequestHandler<CreateHolidayCommand, Result<Holiday>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateHolidayCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Holiday>> Handle(CreateHolidayCommand request, CancellationToken cancellationToken)
    {
        var HolidayType = await _unitOfWork.Repository<HolidayType>().GetByIdAsync(request.HolidayTypeId);
        if(HolidayType == null)
        {
            return Result<Holiday>.BadRequest();
        }
        var mapData = _mapper.Map<Holiday>(request);
        var data = await _unitOfWork.Repository<Holiday>().AddAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<Holiday>.Success(data, "Create Successfully");
    }
}
