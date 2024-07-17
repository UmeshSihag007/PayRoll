using ApwPayroll_Domain.Entities.Designations;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeDesignations
{
    public class EmployeeDesignation
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public bool IsActive { get; set; }

 
        public EmployeeDesignation()
        {
            
        }
        public EmployeeDesignation(int employeeId, int designationId, bool isActive)
        {
            EmployeeId = employeeId;
            DesignationId = designationId;
            IsActive = isActive;
        }
    }
}
