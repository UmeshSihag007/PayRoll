using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.LocationTypes;
using ApwPayroll_Domain.Entities.Locations;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Locations.Commands.CreateLocations;

public class CreateLocationCommand : IRequest<Result<Location>>
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public LocationTypeEnum LocationType { get; set; }
    public int? ParentId { get; set; }

}

internal class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Result<Location>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Result<Location>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {

        var location = _mapper.Map<Location>(request);
        var data = await _unitOfWork.Repository<Location>().AddAsync(location);
        await _unitOfWork.Save(cancellationToken);

        return Result<Location>.Success(data, "Create Successfully");
    }
}
