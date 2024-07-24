using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Departments;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeDepartments.Queries.GetAllEmployeeDepartment;

public class GetAllEmployeeDepartmentQuery : IRequest<Result<List<Department>>>
{
}
internal class GetAllEmployeeDepartmentQueryHandler :  IRequestHandler<GetAllEmployeeDepartmentQuery,Result<List<Department>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEmployeeDepartmentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<Department>>> Handle(GetAllEmployeeDepartmentQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Department>().GetAllAsync();
        if (data == null)
        {
            return Result<List<Department>>.NotFound();
        }
        return Result<List<Department>>.Success(data);
    }
}
