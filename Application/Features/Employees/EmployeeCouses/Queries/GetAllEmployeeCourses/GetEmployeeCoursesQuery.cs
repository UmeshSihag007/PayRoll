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

namespace ApwPayroll_Application.Features.Employees.EmployeeCouses.Queries.GetAllEmployeeCourses;

public class GetEmployeeCoursesQuery:IRequest<Result<List<Course>>>
{
}
internal class GetEmployeeCoursesQueryHandler : IRequestHandler<GetEmployeeCoursesQuery, Result<List<Course>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEmployeeCoursesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<Course>>> Handle(GetEmployeeCoursesQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Course>().GetAllAsync();
        if (data == null)
        {
            return Result<List<Course>>.NotFound();
        }
        return Result<List<Course>>.Success();
    }
}
