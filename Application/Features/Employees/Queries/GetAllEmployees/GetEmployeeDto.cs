using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Application.Features.Employees.EmployeeBankDetails.Commands.CreateEmployeeBankDetails;
using ApwPayroll_Domain.common.Enums.Salutation;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Domain.Entities.Banks.BankDetails;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmergencyContacts;
using ApwPayroll_Domain.Entities.Employees.EmployeeAddresses;
using ApwPayroll_Domain.Entities.Employees.EmployeeDepartments;
using ApwPayroll_Domain.Entities.Employees.EmployeeDesignations;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocuments;
using ApwPayroll_Domain.Entities.Employees.EmployeeExperiences;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Domain.Entities.Employees.EmployeePersonalDetails;
using ApwPayroll_Domain.Entities.Employees.EmployeeQualifications;
using ApwPayroll_Domain.Entities.ReferralDetails;

namespace ApwPayroll_Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetEmployeeDto : IMapFrom<Employee>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? ESINumber { get; set; }
        public string? PfNumber { get; set; }

        public DateTime DateOfJoining { get; set; }
        public int InsuranceNumber { get; set; }
        public Int64 MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string? EmployeeCode { get; set; }
        public string? UserId { get; set; }
        public AspUser? AspUser { get; set; }
        public bool? IsBrokerExamPass { get; set; }
        public DateTime StartedSalary { get; set; }
        public SalutationEnum Salutation { get; set; }
        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }
        public bool IsLoginAccess { get; set; }
        public string? PanNumber { get; set; }
        public Int64? AadharNumber { get; set; }
        public Int64? RationCardNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string? VoterId { get; set; }
        public string? LicenceNumber { get; set; }
        public string? UanNumber { get; set; }


        public List<EmployeeDesignation>? EmployeeDesignations { get; set; } = new List<EmployeeDesignation>();
        public List<EmployeeDepartment>? EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();

        public List<EmployeeDocument> EmployeeDocuments { get; set; } = new List<EmployeeDocument>();
        public CreateEmployeeBankDetailCommand CreateEmployeeBank { get; set; }
        public EmployeePersonalDetail EmployeePersonalDetail { get; set; }
        public List< EmployeeAddress>  EmployeeAddress { get; set; }
        public List<EmergencyContact>? EmergencyContact { get; set; } = new List<EmergencyContact>();
        public List<EmployeeFamily> EmployeeFamily { get; set; } = new List<EmployeeFamily>();
        public List<EmployeeExperience> EmployeeExperience { get; set; } = new List<EmployeeExperience>();
        public List<EmployeeQualification> EmployeeQualification { get; set; } = new List<EmployeeQualification>();
        public List<ReferralDetail> ReferralDetail { get; set; } = new List<ReferralDetail>();
        public List<EmployeeAddress>? EmployeeAddresses { get; set; }
        public List<BankDetail> BankDetails { get; set; }=new List<BankDetail>();
    }
}
