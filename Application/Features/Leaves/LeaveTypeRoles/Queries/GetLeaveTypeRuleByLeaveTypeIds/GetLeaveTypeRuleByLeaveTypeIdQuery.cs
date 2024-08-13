using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypeRoles;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Leaves.LeaveTypeRoles.Queries.GetLeaveTypeRuleByLeaveTypeIds;

public class GetLeaveTypeRuleByLeaveTypeIdQuery : IRequest<LeaveTypeRule>
{
    public int LeaveTypeId { get; set; }

    public GetLeaveTypeRuleByLeaveTypeIdQuery(int leaveTypeId)
    {
        LeaveTypeId = leaveTypeId;
    }
}

internal class GetLeaveTypeRuleByLeaveTypeIdQueryHandler : IRequestHandler<GetLeaveTypeRuleByLeaveTypeIdQuery, LeaveTypeRule>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLeaveTypeRuleByLeaveTypeIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<LeaveTypeRule> Handle(GetLeaveTypeRuleByLeaveTypeIdQuery request, CancellationToken cancellationToken)
    {
        var leaveTypeRule = await _unitOfWork.Repository<LeaveTypeRule>().Entities
            .FirstOrDefaultAsync(rule => rule.LeaveTypeId == request.LeaveTypeId, cancellationToken);

        return leaveTypeRule;
    }
}