using ApwPayroll_Application.Features.Banks.Commands.CreateBankCommands;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Banks.Commands.UpdateBankCommands;

public class UpdateBankCommand : IRequest<Result<int>>
{
    public int? Id { get; set; }
    public CreateBankCommand CreateBankCommand { get; set; }
    public UpdateBankCommand(int? id, CreateBankCommand createBankCommand)
    {
        Id = id;
        CreateBankCommand = createBankCommand;
    }
}
internal class UpdateBankCommandHandler : IRequestHandler<UpdateBankCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBankCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Bank>().GetByIdAsync(request.Id.Value);
        if (data == null)
        {
            return Result<int>.BadRequest();
        }

        var branchExits = await _unitOfWork.Repository<Branch>().GetByIdAsync(request.CreateBankCommand.BranchId);

        if (branchExits == null)
        {
            return Result<int>.BadRequest();
        }
        var mapData = _mapper.Map(request.CreateBankCommand, data);
        await _unitOfWork.Repository<Bank>().UpdateAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();
    }

}
