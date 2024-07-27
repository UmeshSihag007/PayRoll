using ApwPayroll_Application.Features.Locations.Commands.CreateLocations;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Application.Interfaces.Repositories.Documents;
using ApwPayroll_Domain.Entities.Locations;
using ApwPayroll_Domain.Entities.Menus;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Locations.Commands.UpdateLocations;

public class UpdateLocationCommand : IRequest<Result<Location>>
{
    public int Id { get; set; }
    public CreateLocationCommand CreateLcoationCommand { get; set; }

    public UpdateLocationCommand(int id, CreateLocationCommand createLcoationCommand)
    {
        Id = id;
        CreateLcoationCommand = createLcoationCommand;
    }
}
internal class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Result<Location>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Location>> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var existingLocation = await _unitOfWork.Repository<Location>().GetByIdAsync(request.Id);
        if (existingLocation == null)
        {
            return Result<Location>.BadRequest();
        }

      var mapdata=  _mapper.Map(request.CreateLcoationCommand, existingLocation);

        await _unitOfWork.Repository<Location>().UpdateAsync(mapdata);
        await _unitOfWork.Save(cancellationToken);

        return Result<Location>.Success(existingLocation, "Update Successfully");
    }
}

