using ApwPayroll_Application.Features.Branches.Commands.DeleteBranchCommands;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Banks.Commands.DeleteBankCommands;

public class DeleteBankCommand : IRequest<Result<int>>
{
    public DeleteBankCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

}
internal class DeleteBankCommandHandler : IRequestHandler<DeleteBankCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBankCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Bank>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.NotFound();
        }
        await _unitOfWork.Repository<Bank>().DeleteAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();

    }
}
