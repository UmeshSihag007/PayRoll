using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.Salutation;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Domain.Entities.Employees;

namespace ApwPayroll_Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetEmployeeDto : IMapFrom<Employee>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public GenderEnum Gender { get; set; }
        public int ESINumber { get; set; }
        public int PfNumber { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int InsuranceNumber { get; set; }
        public long MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string EmployeeCode { get; set; }
        public string UserId { get; set; }
        public AspUser AspUser { get; set; }
        public bool IsBrokerExamPass { get; set; }
        public DateTime StartedSalary { get; set; }
        public SalutationEnum Salutation { get; set; }
    }
}
