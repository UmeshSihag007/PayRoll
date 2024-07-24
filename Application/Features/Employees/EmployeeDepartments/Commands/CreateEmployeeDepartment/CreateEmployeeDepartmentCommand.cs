using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Departments;
using ApwPayroll_Shared;
using AutoMapper;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeDepartments.Commands.CreateEmployeeDepartment;

public class CreateEmployeeDepartmentCommand:IRequest<Result<int>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}
internal class CreateEmployeeDepartmentCommandHandler : IRequestHandler<CreateEmployeeDepartmentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEmployeeDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateEmployeeDepartmentCommand request, CancellationToken cancellationToken)
    {
        var mapData = _mapper.Map<Department>(request);
        await _unitOfWork.Repository<Department>().AddAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();
    }
}
