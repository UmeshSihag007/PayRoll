using ApwPayroll_Application.Features.Courses.Queries.GetAllCourses;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Leaves.LeaveTypes.Queries.GetAllLeaveTypes;

public class GetAllLeaveTypeQuery : IRequest<Result<List<LeaveType>>>
{
}
internal class GetAllLeaveTypeQueryHandler : IRequestHandler<GetAllLeaveTypeQuery, Result<List<LeaveType>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllLeaveTypeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<LeaveType>>> Handle(GetAllLeaveTypeQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<LeaveType>().GetAllAsync();
        if (data == null)
        {
            return Result<List<LeaveType>>.NotFound();
        }

        return Result<List<LeaveType>>.Success(data);
    }
}