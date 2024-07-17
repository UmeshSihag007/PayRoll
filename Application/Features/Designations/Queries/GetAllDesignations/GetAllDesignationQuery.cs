using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Designations.Queries.GetAllDesignations
{
    public class GetAllDesignationQuery : IRequest<Result<List<GetDesignationDto>>>
    {
    }
    internal class GetAllDesignationQueryHandler : IRequestHandler<GetAllDesignationQuery, Result<List<GetDesignationDto>>>
    {
        private readonly IGenericRepository<Designation> _repository;
        private readonly IMapper _mapper;

        public GetAllDesignationQueryHandler(IGenericRepository<Designation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetDesignationDto>>> Handle(GetAllDesignationQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            var mapData = _mapper.Map<List<GetDesignationDto>>(data);

            return Result<List<GetDesignationDto>>.Success(mapData);
        }
    }
}
