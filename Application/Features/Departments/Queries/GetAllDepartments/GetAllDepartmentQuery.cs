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

namespace ApwPayroll_Application.Features.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentQuery : IRequest<Result<List<GetDepartmentDto>>>
    {
    }
    internal class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, Result<List<GetDepartmentDto>>>
    {
        private readonly IGenericRepository<Department> _repository;
        private readonly IMapper _mapper;

        public GetAllDepartmentQueryHandler(IGenericRepository<Department> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetDepartmentDto>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            var mapData= _mapper.Map<List<GetDepartmentDto>>(data); 
            return Result<List<GetDepartmentDto>>.Success(mapData);
        }
    }
}
 