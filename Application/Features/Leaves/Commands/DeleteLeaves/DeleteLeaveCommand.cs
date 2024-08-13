using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Leaves.Commands.DeleteLeaves;

public class DeleteLeaveCommand : IRequest<Result<int>>
{
    public DeleteLeaveCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

}
internal class DeleteLeaveCommandHandler : IRequestHandler<DeleteLeaveCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLeaveCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteLeaveCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Leave>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.NotFound();
        }
        await _unitOfWork.Repository<Leave>().DeleteAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.BadRequest("Deleted Successfully");

    }
}
