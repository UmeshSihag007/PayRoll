﻿using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Holidays;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Holidays.Queries.GetHolidayByIds;
public class GetHolidayGetByIdQuery : IRequest<Result<Holiday>>
{
    public int Id { get; set; }

    public GetHolidayGetByIdQuery(int id)
    {
        Id = id;
    }
    internal class GetHolidayGetByIdQueryHandler : IRequestHandler<GetHolidayGetByIdQuery, Result<Holiday>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetHolidayGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Holiday>> Handle(GetHolidayGetByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<Holiday>()
            .Entities
           .Include(x => x.HolidayTypeRules)
         .ThenInclude(x => x.HolidayTypeRuleLocations.Where(location => location.IsActive))
         .Where(x => x.Id == request.Id && x.IsDeleted == false)
           .FirstOrDefaultAsync();

            if (data == null)
            {
                return Result<Holiday>.BadRequest();
            }
            return Result<Holiday>.Success(data);
        }
    }
}


