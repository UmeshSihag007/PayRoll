using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Shared;
using AutoMapper;
using Couchbase.Core.Retry;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeFamilies.Queries.GetByEmployeeIdFamilyDetail
{
    public  class GetByEmployeeIdFamilyDetailQuery:IRequest<Result<List<GetEmployeeFamilyDetailDto>>>
    {
        public int EmployeeId { get; set; }

        public GetByEmployeeIdFamilyDetailQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
    internal class GetByEmployeeIdFamilyDetailQueryHandler : IRequestHandler<GetByEmployeeIdFamilyDetailQuery, Result<List<GetEmployeeFamilyDetailDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByEmployeeIdFamilyDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetEmployeeFamilyDetailDto>>> Handle(GetByEmployeeIdFamilyDetailQuery request, CancellationToken cancellationToken)
        {
            
            var checkEmployee = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.EmployeeId);

            if (checkEmployee == null)
            {
                return Result<List<GetEmployeeFamilyDetailDto>>.BadRequest();
            }
            var data=await _unitOfWork.Repository< EmployeeFamily>().Entities.Where(x=>x.EmployeeId == request.EmployeeId && x.IsDeleted==false).ToListAsync();
            if(data == null)
            {
                return Result<List<GetEmployeeFamilyDetailDto>>.NotFound();
            }
            var mapData = _mapper.Map<List<GetEmployeeFamilyDetailDto>>(data);
            return Result<List<GetEmployeeFamilyDetailDto>>.Success(mapData);
        }
    }
}
