using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeDepartments
{
    public class EmployeeDepartment 
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int DepartmentId { get; set; }


        public Department Department { get; set; }
        public bool IsActive {  get; set; }

        public EmployeeDepartment(int departmentId, int employeeId,  bool isActive)
        {
            DepartmentId = departmentId;
            EmployeeId = employeeId;
            IsActive = isActive;
        }
    }
}
