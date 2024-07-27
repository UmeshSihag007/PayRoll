using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.CreateLeaveTypes;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.UpdateLeaveTypes;

public class UpdateLeaveTypeCommand : IRequest<Result<int>>
{
    public UpdateLeaveTypeCommand(int id, CreateLeaveTypeCommand command)
    {
        Id = id;
        this.command = command;
    }

    public int Id { get; set; }

    public CreateLeaveTypeCommand command { get; set; }



}
internal class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<LeaveType>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.BadRequest();
        }

        var mapData = _mapper.Map(request.command, data);
        await _unitOfWork.Repository<LeaveType>().UpdateAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();
    }
}
