using ApwPayroll_Application.Features.Departments.Commands.CreateDepartment;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Departments;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommand : IRequest<Result<Department>>
{
    public UpdateDepartmentCommand(int id, CreateDepartmentCommand command)
    {
        Id = id;
        this.command = command;
    }

    public int Id { get; set; }
    public CreateDepartmentCommand command { get; set; }

}
internal class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Result<Department>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Department>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Department>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<Department>.BadRequest();
        }

        var mapData = _mapper.Map(request.command, data);
        await _unitOfWork.Repository<Department>().UpdateAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<Department>.Success(data, "Update Successfully");
    }
}
