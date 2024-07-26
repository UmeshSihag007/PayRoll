using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Branches.Commands.DeleteBranchCommands;

public class DeleteBranchCommand : IRequest<Result<int>>
{
    public DeleteBranchCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

}
internal class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBranchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Branch>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.NotFound();
        }
        await _unitOfWork.Repository<Branch>().DeleteAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();

    }

}
