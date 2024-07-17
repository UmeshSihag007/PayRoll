using ApwPayroll_Application.Features.Employees.Queries.GetAllEmployees;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Employees.Queries.GetByIdEmployee
{
    public class GetEmployeeByIdQuery : IRequest<Result<GetEmployeeDto>>
    {
        public int EmployeeId { get; set; }

        public GetEmployeeByIdQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
    internal class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Result<GetEmployeeDto>>
    {
        private readonly IGenericRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IGenericRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<GetEmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.Entities.Include(x => x.AspUser).Include(x => x.Salutation).Where(x => x.IsDeleted == false).FirstOrDefaultAsync();
            if (data == null)
            {
                return Result<GetEmployeeDto>.BadRequest();
            }
            var mapData = _mapper.Map<GetEmployeeDto>(data);
            return Result<GetEmployeeDto>.Success(mapData);
        }
    }
}
