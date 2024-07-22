using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeeQuery : IRequest<Result<List<GetEmployeeDto>>>
    {
    }
    internal class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, Result<List<GetEmployeeDto>>>
    {
        private readonly IGenericRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public GetAllEmployeeQueryHandler(IGenericRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<Result<List<GetEmployeeDto>>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {

            var data = await _repository.Entities.Include(x => x.AspUser).Include(x => x.Salutation).Where(x => x.IsDeleted == false).ToListAsync();
            if (data == null)
            {
                return Result<List<GetEmployeeDto>>.NotFound();
            }
            var mapData = _mapper.Map<List<GetEmployeeDto>>(data);
            return Result<List<GetEmployeeDto>>.Success(mapData);
        }
    }
}
