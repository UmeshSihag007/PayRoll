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

namespace ApwPayroll_Application.Features.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommand : IRequest<Result<Department>>
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}
internal class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Result<Department>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Department>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var mapData = _mapper.Map<Department>(request);
       var data= await _unitOfWork.Repository<Department>().AddAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<Department>.Success(data, "Create Successfully");
    }
}
