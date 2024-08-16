using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Leaves.LeaveResponseStatues;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Leaves.LeaveResponseStatues.Queries.GetLeaveResponseStatusByIds;

public class GetLeaveResponseStatusById : IRequest<LeaveResponseStatus>
{
    public int LeaveId { get; set; }

    public GetLeaveResponseStatusById(int leaveId)
    {
        LeaveId = leaveId;
    }
}

internal class GetLeaveResponseStatusByIdHandler : IRequestHandler<GetLeaveResponseStatusById, LeaveResponseStatus>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLeaveResponseStatusByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<LeaveResponseStatus> Handle(GetLeaveResponseStatusById request, CancellationToken cancellationToken)
    {
        var leaveTypeRule = await _unitOfWork.Repository<LeaveResponseStatus>().Entities
            .FirstOrDefaultAsync(rule => rule.LeaveId == request.LeaveId, cancellationToken);

        return leaveTypeRule;
    }
}