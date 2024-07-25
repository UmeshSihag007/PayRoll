using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Departments;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Departments.Queries.GetAllDepartment;

public class GetAllDepartmentQuery : IRequest<Result<List<Department>>>
{
}
internal class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, Result<List<Department>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDepartmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<Department>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Department>().GetAllAsync();
        if (data == null)
        {
            return Result<List<Department>>.NotFound();
        }
        return Result<List<Department>>.Success(data);
    }
}
