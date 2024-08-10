using ApwPayroll_Application.Features.Leaves.Commands.CreateLeaves;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypeRoles;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Leaves.Commands.UpdateLeaves;

public class UpdateLeaveCommand : IRequest<Result<Leave>>
{
    public UpdateLeaveCommand(int id, CreateLeaveCommand command)
    {
        Id = id;
        this.command = command;
    }
    public int Id { get; set; }
    public CreateLeaveCommand command { get; set; }
}
internal class UpdateLeaveCommandHandler : IRequestHandler<UpdateLeaveCommand, Result<Leave>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLeaveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Leave>> Handle(UpdateLeaveCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await _unitOfWork.Repository<LeaveType>().GetByIdAsync(request.command.LeaveTypeId);
        if (leaveType == null)
        {
            return Result<Leave>.BadRequest("Invalid Leave Type.");
        }

        var data = await _unitOfWork.Repository<Leave>().Entities.Include(x=>x.LeaveType).ThenInclude(x=>x.LeaveTypeRole).Where(x=>x.Id==request.Id).FirstOrDefaultAsync();
        if (data == null)
        {
            return Result<Leave>.BadRequest("Leave not found.");
        }

        var mapData = _mapper.Map(request.command, data);
        await _unitOfWork.Repository<Leave>().UpdateAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        var exitsLeaveRule = await _unitOfWork.Repository<LeaveTypeRule>().Entities
                .Where(x => x.LeaveTypeId == data.LeaveTypeId)
                .FirstOrDefaultAsync(cancellationToken);
        if (exitsLeaveRule != null)
        {
            if (exitsLeaveRule.LeaveTypeId != null)
            {
                exitsLeaveRule.LeaveTypeId = data.LeaveTypeId;
            }
            if (exitsLeaveRule.Gender != null)
            {
                exitsLeaveRule.Gender = request.command.LeaveTypeRole.Gender;
            }
            if (exitsLeaveRule.DesignationId != null)
            {
                exitsLeaveRule.DesignationId = request.command.LeaveTypeRole.DesignationId;
            }
            if (exitsLeaveRule.BranchId != null)
            {
                exitsLeaveRule.BranchId = request.command.LeaveTypeRole.BranchId;
            }
            await _unitOfWork.Repository<LeaveTypeRule>().UpdateAsync(exitsLeaveRule);
            await _unitOfWork.Save(cancellationToken);
        }
        return Result<Leave>.Success(data, "Update Successfully");
    }
}
