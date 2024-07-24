using ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.CreateEmployeeCourses;
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

namespace ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.UpdateEmployeeCourses;

public class UpdateEmployeeCourseCommand:IRequest<Result<int>>
{
    public UpdateEmployeeCourseCommand(int id, CreateEmployeeCoursesCommand command)
    {
        Id = id;
        this.command = command;
    }

    public int Id { get; set; }
    public CreateEmployeeCoursesCommand command { get; set; }
  
}
internal class UpdateEmployeeCourseCommandHandler : IRequestHandler<UpdateEmployeeCourseCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateEmployeeCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(UpdateEmployeeCourseCommand request, CancellationToken cancellationToken)
    {
        var data= await _unitOfWork.Repository<Course>().GetByIdAsync(request.Id);
        if (data == null) 
        {
            return Result<int>.BadRequest();
        }

        var mapData= _mapper.Map( request.command,data);
        await _unitOfWork.Repository<Course>().UpdateAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();
    }
}
