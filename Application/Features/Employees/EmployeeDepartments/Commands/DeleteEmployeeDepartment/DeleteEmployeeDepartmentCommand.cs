using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Departments;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.DeleteEmployeeDepartment;

public class DeleteEmployeeDepartmentCommand : IRequest<Result<int>>
{
    public int Id { get; set; }

    public DeleteEmployeeDepartmentCommand(int id)
    {
        Id = id;
    }
}
internal class DeleteEmployeeDepartmentCommandHandler : IRequestHandler<DeleteEmployeeDepartmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeDepartmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteEmployeeDepartmentCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Department>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.NotFound();

        }
        await _unitOfWork.Repository<Department>().DeleteAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();
    }
}
