using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Departments;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Departments.Commands.DeleteDepartment;

public class DeleteDepartmentCommand : IRequest<Result<int>>
{
    public int Id { get; set; }

    public DeleteDepartmentCommand(int id)
    {
        Id = id;
    }
}
internal class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDepartmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Department>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.NotFound();

        }
        await _unitOfWork.Repository<Department>().DeleteAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.BadRequest("Deleted Successfully");
    }
}
