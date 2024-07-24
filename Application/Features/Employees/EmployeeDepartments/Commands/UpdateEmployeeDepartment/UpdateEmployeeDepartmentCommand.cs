using ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.CreateEmployeeDepartment;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Departments;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.UpdateEmployeeDepartment;

public class UpdateEmployeeDepartmentCommand : IRequest<Result<int>>
{
    public UpdateEmployeeDepartmentCommand(int id, CreateEmployeeDepartmentCommand command)
    {
        Id = id;
        this.command = command;
    }

    public int Id { get; set; }
    public CreateEmployeeDepartmentCommand command { get; set; }

}
internal class UpdateEmployeeDepartmentCommandHandler : IRequestHandler<UpdateEmployeeDepartmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateEmployeeDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(UpdateEmployeeDepartmentCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Department>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.BadRequest();
        }

        var mapData = _mapper.Map (request.command,data);
        await _unitOfWork.Repository<Department>().UpdateAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();
    }
}
