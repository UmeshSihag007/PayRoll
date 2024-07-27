using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Branches.Queries.GetBranchByIds;

public class GetBranchByIdQuery : IRequest<Result<Branch>>
{
    public int Id { get; set; }

    public GetBranchByIdQuery(int id)
    {
        Id = id;
    }
    internal class GetBranchByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, Result<Branch>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBranchByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Branch>> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<Branch>().GetByIdAsync(request.Id);
            if (data == null)
            {
                return Result<Branch>.BadRequest();
            }
            var mapData = _mapper.Map<Branch>(data);
            return Result<Branch>.Success(mapData);
        }
    }
}
