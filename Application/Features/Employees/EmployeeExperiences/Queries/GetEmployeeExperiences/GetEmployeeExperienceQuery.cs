﻿using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.EmployeeExperiences;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Employees.EmployeeExperiences.Queries.GetEmployeeExperiences
{
    public class GetEmployeeExperienceQuery : IRequest<Result<List<GetEmployeeExperienceDto>>>
    {
        public int Id { get; set; }

        public GetEmployeeExperienceQuery(int id)
        {
            Id = id;
        }
    }
    internal class GetEmployeeExperienceQueryHandler : IRequestHandler<GetEmployeeExperienceQuery, Result<List<GetEmployeeExperienceDto>>>
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmployeeExperienceQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetEmployeeExperienceDto>>> Handle(GetEmployeeExperienceQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<EmployeeExperience>().Entities.Where(x => x.EmployeeId == request.Id && x.IsDeleted == false).ToListAsync();
            if (data == null)
            {
                return Result<List<GetEmployeeExperienceDto>>.NotFound();
            }
            var mapData = _mapper.Map<List<GetEmployeeExperienceDto>>(data);
            return Result<List<GetEmployeeExperienceDto>>.Success(mapData);
        }
    }
}
