//using ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Commands.CreateEmployeePersonalDetail;
//using ApwPayroll_Application.Features.Employees.Queries.GetAllEmployees;
//using ApwPayroll_Application.Features.Employees.Queries.GetByIdEmployee;
//using ApwPayroll_Application.Interfaces.Repositories;
//using ApwPayroll_Domain.Entities.Employees;
//using ApwPayroll_Shared;
//using AutoMapper;
//using Couchbase.Core.Retry;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Queries.GetByIdEmployeePersonal
//{
//    public class GetEmployeePersonalByIdQuery : IRequest<Result<GetEmployeeDto>>
//    {
//        public int Id { get; set; }

//        public GetEmployeePersonalByIdQuery(int id)
//        {
//            Id = id;
//        }
//    }
//    internal class GetEmployeePersonalByIdQueryHandler : IRequestHandler<GetEmployeePersonalByIdQuery, Result<GetEmployeeDto>>
//    {
//        private readonly IGenericRepository<Employee> _repository;
//        private readonly IMapper _mapper;

//        public GetEmployeePersonalByIdQueryHandler(IGenericRepository<Employee> repository, IMapper mapper)
//        {
//            _repository = repository;
//            _mapper = mapper;
//        }
//        public async Task<Result<GetEmployeeDto>> Handle(GetEmployeePersonalByIdQuery request, CancellationToken cancellationToken)
//        {
//            try
//            {
//                var data = await _repository.Entities
//                  .Include(x => x.AspUser)
//                   .Include(x => x.EmployeePersonalDetail)
//                  .Include(x => x.EmployeeDocuments).ThenInclude(x => x.EmployeeDocumentType)
//                  .Include(x => x.EmployeeDocuments).ThenInclude(x => x.Document)
//                    .Include(x => x.EmployeeQualification).ThenInclude(x => x.Course)
//                 .Include(x => x.EmployeeExperience)
//                 .Include(x => x.Branch)
//                  .Include(x => x.EmployeeFamily).ThenInclude(x => x.RelationType)
//            .Include(x => x.ReferralDetail)
//         .Include(x => x.EmployeeDesignations)
//          .Include(x => x.EmergencyContact)
//          .Include(x => x.BankDetails)
//          .Include(X => X.EmployeeAddresses).ThenInclude(X => X.AddressType)
//         .Include(x => x.EmployeeDepartments)
//                .FirstOrDefaultAsync(e => e.Id == request.Id && e.IsDeleted == false, cancellationToken: cancellationToken);

//                if (data == null)
//                {
//                    return Result<GetEmployeeDto>.NotFound();
//                }

//                var employeeDto = _mapper.Map<GetEmployeeDto>(data);
//                return Result<GetEmployeeDto>.Success(employeeDto);
//            }
//            catch (Exception ex)
//            {

//                var msg = ex.Message;

//            }
//            return null;
//        }

//        public Task<Result<GetEmployeeDto>> Handle(GetEmployeePersonalByIdQuery request, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
