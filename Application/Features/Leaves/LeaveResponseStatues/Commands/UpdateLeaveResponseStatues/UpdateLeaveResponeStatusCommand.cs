using ApwPayroll_Application.Features.Leaves.LeaveResponseStatues.Commands.CreateLeaveResponseStatues;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Domain.Entities.Leaves.LeaveResponseStatues;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Leaves.LeaveResponseStatues.Commands.UpdateLeaveResponseStatues;

public class UpdateLeaveResponeStatusCommand : IRequest<Result<LeaveResponseStatus>>
{
    public UpdateLeaveResponeStatusCommand(int id, CreateLeaveResponeStatusCommand command, int? leaveId)
    {
        Id = id;
        this.command = command;
        LeaveId = leaveId;
    }
    public int Id { get; set; }
    public int? LeaveId { get; set; }
    public CreateLeaveResponeStatusCommand command { get; set; }
}
internal class UpdateLeaveResponeStatusCommandHandler : IRequestHandler<UpdateLeaveResponeStatusCommand, Result<LeaveResponseStatus>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLeaveResponeStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<LeaveResponseStatus>> Handle(UpdateLeaveResponeStatusCommand request, CancellationToken cancellationToken)
    {
        var existingLeaveResponseStatus = await _unitOfWork.Repository<LeaveResponseStatus>()
            .Entities.Include(x => x.Leave)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (existingLeaveResponseStatus == null)
        { 
            return Result<LeaveResponseStatus>.BadRequest("Leave Response Status not found.");
        }

        var existingLeave = await _unitOfWork.Repository<Leave>()
            .Entities.FirstOrDefaultAsync(x => x.Id == request.LeaveId, cancellationToken);

        if (existingLeave == null)
        {
            return Result<LeaveResponseStatus>.BadRequest("Leave not found.");
        }

        _mapper.Map(request.command, existingLeaveResponseStatus);


        await _unitOfWork.Repository<LeaveResponseStatus>().UpdateAsync(existingLeaveResponseStatus);

        await _unitOfWork.Save(cancellationToken);

        return Result<LeaveResponseStatus>.Success(existingLeaveResponseStatus, "Update Successfully");
    }

}
