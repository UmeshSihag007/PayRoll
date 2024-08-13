using ApwPayroll_Application.Features.Holidays.Commands.CreateHolidays;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Holidays;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypeRoles;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Holidays.Commands.UpdateHolidays
{
    public class UpdateHolidayCommand : IRequest<Result<Holiday>>
    {
        public int Id { get; set; }
        public CreateHolidayCommand CreateHolidayCommand { get; set; }

        public UpdateHolidayCommand(int id, CreateHolidayCommand createHolidayCommand)
        {
            Id = id;
            CreateHolidayCommand = createHolidayCommand;
        }
    }

    internal class UpdateHolidayCommandHandler : IRequestHandler<UpdateHolidayCommand, Result<Holiday>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateHolidayCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Holiday>> Handle(UpdateHolidayCommand request, CancellationToken cancellationToken)
        {
            var holidayType = await _unitOfWork.Repository<HolidayType>().GetByIdAsync(request.CreateHolidayCommand.HolidayTypeId);
            if (holidayType == null)
            {
                return Result<Holiday>.BadRequest("Invalid Holiday Type.");
            }

            var holiday = await _unitOfWork.Repository<Holiday>().GetByIdAsync(request.Id);
            if (holiday == null)
            {
                return Result<Holiday>.BadRequest("Holiday not found.");
            }

            _mapper.Map(request.CreateHolidayCommand, holiday);

            _unitOfWork.Repository<Holiday>().UpdateAsync(holiday);
            await _unitOfWork.Save(cancellationToken);

            var exitsRule = await _unitOfWork.Repository<HolidayTypeRule>().Entities
                .Where(x => x.HolidayId == request.Id)
                .Include(x=>x.HolidayTypeRuleLocations)
                .FirstOrDefaultAsync(cancellationToken);

            if (exitsRule != null)
            {
                if (exitsRule.Gender != null)
                {
                    exitsRule.Gender = request.CreateHolidayCommand.HolidayRuleDto.Gender;
                }
                if (exitsRule.BranchId != null)
                {
                    exitsRule.BranchId = request.CreateHolidayCommand.HolidayRuleDto.BranchId;
                }
                if (exitsRule.HolidayTypeRuleLocations != null)
                {
                     exitsRule.AddIfNotLocationExists(request.CreateHolidayCommand.HolidayRuleDto.LocationId);

                }

                await _unitOfWork.Repository<HolidayTypeRule>().UpdateAsync(exitsRule);
                await _unitOfWork.Save(cancellationToken);
            }

            return Result<Holiday>.Success(holiday, "Update Successfully");
        }
    }
}
