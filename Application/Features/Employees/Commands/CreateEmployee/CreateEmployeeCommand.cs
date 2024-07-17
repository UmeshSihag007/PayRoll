using ApwPayroll_Application.Common.Exceptions;
using ApwPayroll_Application.Features.Employees.EmployeeAddresses.Commands.CreateEmployeeAddress;
using ApwPayroll_Application.Features.Employees.EmployeeContact.Commands.CreateEmployeeContact;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.Salutation;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Domain.Entities.Departments;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApwPayroll_Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Result<Employee>>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
  
        [ESINumber]
        public string? ESINumber { get; set; }
        [PFNumber]
        public string? PfNumber { get; set; }
         public DateTime DateOfJoining { get; set; }
        public int InsuranceNumber { get; set; }
        [MobileNumber]
        public Int64 MobileNumber { get; set; }
        [Email]
        public string EmailId { get; set; }
 
 
        public string? UserId { get; set; }
        public bool? IsBrokerExamPass { get; set; }
        public DateTime StartedSalary { get; set; }
        public SalutationEnum Salutation { get; set; }
        public int? BranchId { get; set; }
        public bool IsLoginAccess { get; set; }
        [PanNumber]
        public string? PanNumber { get; set; }
        [AadharNumber]
        public Int64? AadharNumber { get; set; }
        [RationCardNumber]
        public Int64? RationCardNumber { get; set; }
        [PassportNumber]
        public string? PassportNumber { get; set; }
        [VoterId]
        public string? VoterId { get; set; }
        [Licence]
        public string? LicenceNumber { get; set; }
        [UanNumber]
        public string? UanNumber { get; set; }
 
        public List<int> DesignationId { get; set; }
        public List<int> DepartmentId { get; set; }
 
    }
    internal class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<Employee>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AspUser> _userManager;

        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AspUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Result<Employee>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        { 
            
            var user = new AspUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.EmailId,
            };
            var mapData = _mapper.Map<Employee>(request);
            var empCode = GenerateEmployeeCode();
            mapData.EmployeeCode = empCode;
            var data = await _unitOfWork.Repository<Employee>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);

            var password = GeneratePassword(request.EmailId);
            await _userManager.CreateAsync(user, password);
           
 
            if ( request.DesignationId!=null)
 
            {
                foreach (var designation in request.DesignationId)
                {
                    var checkDesignation = await _unitOfWork.Repository<Designation>().GetByIdAsync(designation);
                    if (checkDesignation == null)
                    {
                        return Result<Employee>.BadRequest();
                    }
                    data.AddDesignation(designation);
                 }
            }
            if ( request.DepartmentId!=null)
            {
                foreach (var department in request.DepartmentId)
                {
                    var checkDepartment = await _unitOfWork.Repository<Department>().GetByIdAsync(department);
                    if (checkDepartment == null)
                    {
                        return Result<Employee>.BadRequest();
                    }
                    data.AddDesignation(department);
                }
             }
 
             
           if (request. DepartmentId!=null)
            {
                foreach (var department in request.DepartmentId)
                {
                    var checkDepartment = await _unitOfWork.Repository<Department>().GetByIdAsync(department);
                    if (checkDepartment == null)
                    {
                        return Result<Employee>.BadRequest();
                    }
                    data.AddDesignation(department);
                }
            }
 

             return Result<Employee>.Success(data, "Created SuccessFully");
           }
  
        private string GeneratePassword(string email)
        {
            string password = email + "@123";
            return password;
        }
 
        private string GenerateEmployeeCode()
        {
            var random = new Random();
            var randomNumber = random.Next(100, 1000);  
            var employeeCode = "Emp" + randomNumber.ToString();
            return employeeCode;
        }

 
    }


}
