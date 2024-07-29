using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.AccountType;
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Banks.Queries.GetAllBanks;

public class GetAllBankQuery : IRequest<Result<List<GetBankDto>>>
{
}

internal class GetAllBankQueryHandler : IRequestHandler<GetAllBankQuery, Result<List<GetBankDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllBankQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<GetBankDto>>> Handle(GetAllBankQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Bank>()
            .Entities
            .Include(x => x.Branch)
            .Where(x => !x.IsDeleted)
            .ToListAsync(cancellationToken);

        var mapData = _mapper.Map<List<GetBankDto>>(data);

        foreach (var bank in mapData)
        {
            var originalBank = data.FirstOrDefault(b => b.Id == bank.Id);
            bank.BranchName = originalBank?.Branch?.Name;
        }

        return Result<List<GetBankDto>>.Success(mapData);
    }
}

public class GetBankDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int EmployeeId { get; set; }
    public bool IsBankAccountVerified { get; set; }
    public int AccountNumber { get; set; }
    public string IFCCode { get; set; }
    public string AccountName { get; set; }
    public AccountTypeEnum AccountType { get; set; }
    public int BranchId { get; set; }

    public string BranchName { get; set; }
}
