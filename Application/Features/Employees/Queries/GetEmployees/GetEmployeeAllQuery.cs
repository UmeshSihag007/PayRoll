using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.Queries.GetEmployees;

public class GetEmployeeAllQuery : IRequest<Result<List<Employee>>>
{

}
internal class GetEmployeeAllQueryHandler : IRequestHandler<GetEmployeeAllQuery, Result<List<Employee>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEmployeeAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<Employee>>> Handle(GetEmployeeAllQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Employee>().GetAllAsync();
        if (data == null)
        {
            return Result<List<Employee>>.NotFound();
        }

        return Result<List<Employee>>.Success(data);
    }
}
