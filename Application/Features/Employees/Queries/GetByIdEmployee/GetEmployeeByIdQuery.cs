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
            try
            {
                var data = await _repository.Entities
                  .Include(x => x.AspUser)
                   .Include(x => x.EmployeePersonalDetail)
                  .Include(x => x.EmployeeDocuments).ThenInclude(x => x.EmployeeDocumentType)
                  .Include(x => x.EmployeeDocuments).ThenInclude(x => x.Document)
                    .Include(x => x.EmployeeQualification).ThenInclude(x => x.Course)
                 .Include(x => x.EmployeeExperience)
                 .Include(x => x.Branch)
                  .Include(x => x.EmployeeFamily).ThenInclude(x => x.RelationType)
            .Include(x => x.ReferralDetail)
         .Include(x=>x.EmployeeDesignations).ThenInclude(x=>x.Designation)
         .Include(x=>x.EmployeeDepartments).ThenInclude(x=>x.Department)
          .Include(x=>x.EmergencyContact)
          .Include(x=>x.BankDetails)
          .Include(X=>X.EmployeeAddresses).ThenInclude(X=>X.AddressType)
        
         .Include(x=>x.EmployeeDepartments)
                .FirstOrDefaultAsync(e => e.Id == request.EmployeeId && e.IsDeleted == false, cancellationToken: cancellationToken);
 
            if (data == null)
            {
                return Result<GetEmployeeDto>.NotFound();
            }
 
            var employeeDto = _mapper.Map<GetEmployeeDto>(data);
            return Result<GetEmployeeDto>.Success(employeeDto);
            }
            catch (Exception ex)
            {

                var msg = ex.Message;
               
            }
            return null;
        }

     
    }
}
