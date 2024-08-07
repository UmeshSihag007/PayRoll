using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.Entities.Holidays;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypeRoles;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Holidays.Commands.CreateHolidays;

public class CreateHolidayCommand : IRequest<Result<Holiday>>
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public DateTime ToDate { get; set; }
    public DateTime FromDate { get; set; }
    public bool IsNotifyToEmployee { get; set; }
    public bool IsResetToLeaveRequest { get; set; }
    public string Description { get; set; }
    public int HolidayTypeId { get; set; }

    public GetHolidayRuleDto HolidayRuleDto { get; set; }
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
        // Validate if HolidayRuleDto is provided
        if (request.HolidayRuleDto == null || !IsHolidayRuleDtoValid(request.HolidayRuleDto))
        {
            return Result<Holiday>.BadRequest("Please provide a valid holiday rule.");
        }

        var holidayType = await _unitOfWork.Repository<HolidayType>().GetByIdAsync(request.HolidayTypeId);
        if (holidayType == null)
        {
            return Result<Holiday>.BadRequest("Invalid Holiday Type");
        }

        var mapData = _mapper.Map<Holiday>(request);
        var holiday = await _unitOfWork.Repository<Holiday>().AddAsync(mapData);

        await _unitOfWork.Save(cancellationToken);

        var holidayRule = new HolidayTypeRule
        {
            HolidayId = holiday.Id,
            Gender = request.HolidayRuleDto.Gender,
            BranchId = request.HolidayRuleDto.BranchId
        };

        await _unitOfWork.Repository<HolidayTypeRule>().AddAsync(holidayRule);

        await _unitOfWork.Save(cancellationToken);

        /* if (request.HolidayRuleDto.LocationId != null && request.HolidayRuleDto.LocationId.Any())
         {
             foreach (var locationId in request.HolidayRuleDto.LocationId)
             {
                 var location = new HolidayTypeRuleLocation
                 {
                     LocationId = locationId,
                     HolidayRuleTypeId = holidayRule.Id
                 };

                 await _unitOfWork.Repository<HolidayTypeRuleLocation>().AddAsync(location);
             }
         }*/

        await _unitOfWork.Save(cancellationToken);

        return Result<Holiday>.Success(holiday, "Created Successfully");
    }

    private bool IsHolidayRuleDtoValid(GetHolidayRuleDto holidayRuleDto)
    {
        return holidayRuleDto.Gender != null && holidayRuleDto.BranchId > 0;
    }
}



public class GetHolidayRuleDto
{
    public GenderEnum Gender { get; set; }
    //public List<int> LocationId { get; set; } = new List<int>();
    public int BranchId { get; set; }
}
