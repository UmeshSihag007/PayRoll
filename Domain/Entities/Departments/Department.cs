using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Employees.EmployeeDepartments;

namespace ApwPayroll_Domain.Entities.Departments
{
    public class Department : BaseAuditEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }

    }
}
