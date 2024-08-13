using ApwPayroll_Application.Features.Employees.Queries.GetAllEmployees;
using ApwPayroll_Application.Features.Employees.Queries.SearchEmployee;

namespace ApwPayrollWebApp.Models
{
    public class EmployeeIndexViewModel
    {
        public List<GetEmployeeDto> Employees { get; set; }
        public PaginationViewModel Pagination { get; set; }
        public SearchEmployeeDto SearchEmployee { get; set; }
    }
}
