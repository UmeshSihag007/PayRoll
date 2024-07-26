using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.AccountType;
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Banks.Commands.CreateBankCommands;

public class CreateBankCommand : IRequest<Result<int>>
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public int EmployeeId { get; set; } 
    public bool IsBankAccountVerified { get; set; }
    public int AccountNumber { get; set; }
    public string IFCCode { get; set; }
    public string AccountName { get; set; }
    public AccountTypeEnum AccountType { get; set; }
    public int BranchId { get; set; }
}
internal class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBankCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateBankCommand request, CancellationToken cancellationToken)
    { 
        var branchExits = await _unitOfWork.Repository<Branch>().GetByIdAsync(request.BranchId);

        if (branchExits == null)
        {
            return Result<int>.BadRequest();
        }
        var mapData = _mapper.Map<Bank>(request);
        request.EmployeeId = 1;
        await _unitOfWork.Repository<Bank>().AddAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();
    }
}
