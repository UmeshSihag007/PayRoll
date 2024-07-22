using ApwPayroll_Application.Contracts.Dtos;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Banks.Queries.GetAllBanks;

public class GetBankLookUpQuery : IRequest<Result<List<LookUpDto>>>
{
}

internal class GetBankLookUpQueryHandler : IRequestHandler<GetBankLookUpQuery, Result<List<LookUpDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBankLookUpQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<LookUpDto>>> Handle(GetBankLookUpQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Bank>().GetAllAsync();
        if (data == null)
        {
            return Result<List<LookUpDto>>.NotFound();
        }
        var mapData = _mapper.Map<List<LookUpDto>>(data);
        return Result<List<LookUpDto>>.Success(mapData);
    }
}


