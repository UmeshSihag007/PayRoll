using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.DeleteLeaveTypes;

public class DeleteLeaveTypeCommand : IRequest<Result<int>>
{
    public DeleteLeaveTypeCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

}
internal class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLeaveTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<LeaveType>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.NotFound();
        }
        await _unitOfWork.Repository<LeaveType>().DeleteAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();

    }
}
