using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Shared;
using AutoMapper;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Courses.Queries.GetAllDepartments;

public class GetAllCoursesQuery:IRequest<Result<List<GetAllCoursesDto>>>
{
}
internal class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, Result<List<GetAllCoursesDto>>>
{
    private readonly IGenericRepository<Course> _repository;
    private readonly IMapper _mapper;

    public GetAllCoursesQueryHandler(IGenericRepository<Course> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllCoursesDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetAllAsync();
        var mapData= _mapper.Map<List<GetAllCoursesDto>>(data);    
        return Result<List<GetAllCoursesDto>>.Success(mapData);
    }
}
