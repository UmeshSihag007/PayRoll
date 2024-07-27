using ApwPayroll_Application.Contracts.Dtos;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Branches.Queries.GetBranchLookUpQuery;

public class GetBranchLookUpQuery : IRequest<Result<List<LookUpDto>>>
{
}

internal class GetBranchLookUpQueryHandler : IRequestHandler<GetBranchLookUpQuery, Result<List<LookUpDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBranchLookUpQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<LookUpDto>>> Handle(GetBranchLookUpQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Branch>().GetAllAsync();
        if (data == null)
        {
            return Result<List<LookUpDto>>.NotFound();
        }
        var mapData = _mapper.Map<List<LookUpDto>>(data);
        return Result<List<LookUpDto>>.Success(mapData);
    }

}
