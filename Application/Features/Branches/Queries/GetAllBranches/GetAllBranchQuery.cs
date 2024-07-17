using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Branches.Queries.GetAllBranches
{
    public class GetAllBranchQuery : IRequest<Result<List<GetBranchDto>>>
    {
    }
    internal class GetAllBranchQueryHandler : IRequestHandler<GetAllBranchQuery, Result<List<GetBranchDto>>>
    {
        private readonly IGenericRepository<Branch> _repository;
        private readonly IMapper _mapper;
        public GetAllBranchQueryHandler(IGenericRepository<Branch> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<List<GetBranchDto>>> Handle(GetAllBranchQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            var mapData = _mapper.Map<List<GetBranchDto>>(data);
            return Result<List<GetBranchDto>>.Success(mapData);
        }
    }
}
