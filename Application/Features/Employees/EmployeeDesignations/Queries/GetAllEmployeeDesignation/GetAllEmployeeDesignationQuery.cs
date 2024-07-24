using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeDesignations.Queries.GetAllEmployeeDesignation;

public class GetAllEmployeeDesignationQuery : IRequest<Result<List<Designation>>>
{

}
internal class GetAllEmployeeDesignationQueryHandler : IRequestHandler<GetAllEmployeeDesignationQuery, Result<List<Designation>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEmployeeDesignationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
 

    async Task<Result<List<Designation>>> IRequestHandler<GetAllEmployeeDesignationQuery, Result<List<Designation>>>.Handle(GetAllEmployeeDesignationQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Designation>().GetAllAsync();
        if (data == null)
        {
            return Result<List<Designation>>.NotFound();
        }
        return Result<List<Designation>>.Success();
    }
}
