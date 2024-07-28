using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Holidays;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Holidays.Queries.GetAllHolidays
{
    public class GetAllHolidayQuery : IRequest<Result<List<Holiday>>>
    {
    }

    internal class GetAllHolidayQueryHandler : IRequestHandler<GetAllHolidayQuery, Result<List<Holiday>>>
    {
        private readonly IGenericRepository<Holiday> _repository;
        private readonly IMapper _mapper;

        public GetAllHolidayQueryHandler(IGenericRepository<Holiday> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<Holiday>>> Handle(GetAllHolidayQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.Entities.Include(x => x.HolidayType).Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);
            if (data == null)
            {
                return Result<List<Holiday>>.NotFound();
            }
            var mapData = _mapper.Map<List<Holiday>>(data);
            return Result<List<Holiday>>.Success(mapData);
        }
    }
}
