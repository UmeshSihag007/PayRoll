using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.UpdateStatus;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Branches.Commands.UpdateBranchStatusCommands;

public class UpdateBranchStatusCommand : IRequest<Result<Branch>>

{
    public UpdateBranchStatusCommand(int id, bool isActive)
    {
        Id = id;
        IsActive = isActive;
    }

    public int Id { get; set; }
    public bool IsActive { get; set; }
}

internal class UpdateBranchStatusCommandHandler : IRequestHandler<UpdateBranchStatusCommand, Result<Branch>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBranchStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Branch>> Handle(UpdateBranchStatusCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Branch>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<Branch>.BadRequest();
        }

        data.IsActive = request.IsActive;
        await _unitOfWork.Repository<Branch>().UpdateAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<Branch>.Success(data, data.IsActive ? "Branch is now Active." : "Branch is now Disactive.");
    }
}
