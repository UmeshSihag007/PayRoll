using ApwPayroll_Application.Features.Employees.Queries.SearchEmployee;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeeQuery : IRequest<Result<PaginatedResult<GetEmployeeDto>>>
    {
        public int PageNumber { get; set; }  
        public int PageSize { get; set; }  

        public SearchEmployeeDto? SearchEmployee { get; set; }
        public GetAllEmployeeQuery(int pageNumber, int pageSize, SearchEmployeeDto? searchEmployee)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchEmployee = searchEmployee;
        }
    }
    internal class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, Result<PaginatedResult<GetEmployeeDto>>>
    {
        private readonly IGenericRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public GetAllEmployeeQueryHandler(IGenericRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<PaginatedResult<GetEmployeeDto>>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            // Fetch all non-deleted employees from the database
            var data = await _repository.Entities
                .Where(x => x.IsDeleted == false)
                .Include(x=>x.EmployeeDepartments)
                .Include(x=>x.EmployeeDesignations)
                .Include(x => x.AspUser)

                .ToListAsync(cancellationToken);

            // Check if data is found
            if (!data.Any())
            {
                return Result<PaginatedResult<GetEmployeeDto>>.NotFound();
            }

            // Map data to DTOs
            var mapData = _mapper.Map<List<GetEmployeeDto>>(data);

            // Apply search filters if provided
            if (request.SearchEmployee != null)
            {
                if (!string.IsNullOrWhiteSpace(request.SearchEmployee.Name))
                {
                    mapData = mapData.Where(x => x.FirstName.Contains(request.SearchEmployee.Name) ||
                                                 x.LastName.Contains(request.SearchEmployee.Name)).ToList();
                }
                if (!string.IsNullOrWhiteSpace(request.SearchEmployee.Email))
                {
                    mapData =   mapData.Where(x => x.EmailId == request.SearchEmployee.Email).ToList();
                }
                if (request.SearchEmployee.MobileNumber.HasValue)
                {
                    mapData = mapData.Where(x => x.MobileNumber == request.SearchEmployee.MobileNumber).ToList();
                }  
                if (request.SearchEmployee.DateOfJoining.HasValue)
                {
                  
                        DateTime searchDate = request.SearchEmployee.DateOfJoining.Value.Date; // Get only the date part
                        mapData = mapData.Where(x => x.DateOfJoining.Date == searchDate).ToList();
                
                }
                if (request.SearchEmployee.BranchId != 0 )
                {
                    mapData = mapData.Where(x => x.BranchId == request.SearchEmployee.BranchId).ToList();
                }
                if (request.SearchEmployee.DesignationId != null && request.SearchEmployee.DesignationId!=0)
                {
                    mapData = mapData.Where(x => x.EmployeeDesignations.Any(d => d.DesignationId == request.SearchEmployee.DesignationId)).ToList();
                }

                if (request.SearchEmployee.DepartmentId != null && request.SearchEmployee.DepartmentId!=0)
                {
                    mapData = mapData.Where(x => x.EmployeeDepartments.Any(d => d.DepartmentId == request.SearchEmployee.DepartmentId)).ToList();
                }
                if (request.SearchEmployee.PanNumber != null )
                {
                    mapData = mapData.Where(x => x.PanNumber == request.SearchEmployee.PanNumber).ToList();
                }
                if (request.SearchEmployee.EmployeeCode != null)
                {
                    mapData = mapData.Where(x => x.EmployeeCode == request.SearchEmployee.EmployeeCode).ToList();

                }
            }

            // Calculate the total count after filtering
            var totalCount = mapData.Count;

            // Apply pagination
            var paginatedData = mapData
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            // Create and return paginated result
            var paginatedResult = PaginatedResult<GetEmployeeDto>.Create(paginatedData, totalCount, request.PageNumber, request.PageSize);
            return Result<PaginatedResult<GetEmployeeDto>>.Success(paginatedResult);
        }


    }
}