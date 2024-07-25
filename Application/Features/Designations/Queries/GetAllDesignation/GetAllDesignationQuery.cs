using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Designations.Queries.GetAllDesignation;

public class GetAllDesignationQuery : IRequest<Result<List<Designation>>>
{

}
internal class GetAllDesignationQueryHandler : IRequestHandler<GetAllDesignationQuery, Result<List<Designation>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDesignationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    async Task<Result<List<Designation>>> IRequestHandler<GetAllDesignationQuery, Result<List<Designation>>>.Handle(GetAllDesignationQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Designation>().GetAllAsync();
        if (data == null)
        {
            return Result<List<Designation>>.NotFound();
        }
        return Result<List<Designation>>.Success(data);
    }
}
