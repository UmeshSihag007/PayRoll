using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.LocationTypes;
using ApwPayroll_Domain.Entities.Locations;
using ApwPayroll_Domain.Entities.Menus.MenuTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Locations.Commands.CreateLocations;

public class CreateLcoationCommand : IRequest<Result<Location>>
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public LocationTypeEnum LocationType { get; set; }
    public int? ParentId { get; set; }
  
}

internal class CreateLcoationCommandHandler : IRequestHandler<CreateLcoationCommand, Result<Location>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateLcoationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Result<Location>> Handle(CreateLcoationCommand request, CancellationToken cancellationToken)
    {

           var location = _mapper.Map<Location>(request);
            await _unitOfWork.Repository<Location>().AddAsync(location);
            await _unitOfWork.Save(cancellationToken);

        return Result<Location>.Success(location);
    }
}
