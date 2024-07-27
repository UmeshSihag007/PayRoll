using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Locations;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Locations.Commands.DeleteLocations;

public class DeleteLocationCommand : IRequest<Result<int>>
{
    public int Id { get; set; }

    public DeleteLocationCommand(int id)
    {
        Id = id;
    }
}
internal class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {

        var data = await _unitOfWork.Repository<Location>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.BadRequest();
        }
        await _unitOfWork.Repository<Location>().DeleteAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();
    }


}


