using ApwPayroll_Application.Features.Locations.Queries.GetAllLocations;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Locations;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Locations.Queries.GetLocationByIds;

public class GetLocationByIdQuery : IRequest<Result<Location>>
{
    public int Id { get; set; }

    public GetLocationByIdQuery(int id)
    {
        Id = id;
    }
    internal class GetDocumentTypeByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, Result<Location>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDocumentTypeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Location>> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<Location>().GetByIdAsync(request.Id);
            if (data == null)
            {
                return Result<Location>.BadRequest();
            }
            var mapData = _mapper.Map<Location>(data);
            return Result<Location>.Success(mapData);
        }
    }

}
