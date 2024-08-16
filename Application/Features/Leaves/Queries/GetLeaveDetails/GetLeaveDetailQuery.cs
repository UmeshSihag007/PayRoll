using ApwPayroll_Application.Features.Leaves.Queries.GetLeaveAllDto;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Leaves.tQueries.GetLeaveDetails;

public class GetLeaveDetailQuery : IRequest<Result<List<LeaveAllDto>>>
{


}
internal class GetLeaveDetailQueryHandler : IRequestHandler<GetLeaveDetailQuery, Result<List<LeaveAllDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetLeaveDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Result<List<LeaveAllDto>>> Handle(GetLeaveDetailQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Leave>().Entities
            .Include(x => x.LeaveType)
                .ThenInclude(x => x.LeaveTypeRole) // Include LeaveTypeRole
      .ThenInclude(x => x.Designation)
 
            .Include(x => x.LeaveType)
                .ThenInclude(x => x.LeaveTypeRole) // Include LeaveTypeRole
            .Include(x => x.LeaveResponseStatus)
                .ThenInclude(r => r.Employee)  // Include Employee in LeaveResponseStatus
            .Include(x => x.LeaveResponseStatus)
                .ThenInclude(r => r.Forword)   // Include Forword in LeaveResponseStatus
            .ToListAsync(cancellationToken); // Passing cancellationToken is a good practice

        if (data == null || !data.Any())
        {
            return Result<List<LeaveAllDto>>.BadRequest("Data not found");
        }

        var mapData = _mapper.Map<List<LeaveAllDto>>(data);
        return Result<List<LeaveAllDto>>.Success(mapData);
    }

}