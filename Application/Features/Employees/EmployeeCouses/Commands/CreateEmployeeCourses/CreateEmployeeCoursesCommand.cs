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

namespace ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.CreateEmployeeCourses;

public class CreateEmployeeCoursesCommand:IRequest<Result<int>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
internal class CreateEmployeeCoursesCommandHandler : IRequestHandler<CreateEmployeeCoursesCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEmployeeCoursesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateEmployeeCoursesCommand request, CancellationToken cancellationToken)
    {
        var mapData = _mapper.Map<Course>(request);
        await _unitOfWork.Repository<Course>().AddAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();
    }
}
