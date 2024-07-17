using ApwPayroll_Domain.common;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeSocials
{
    public class EmployeeSocial : BaseAuditEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string LinkdinUrl { get; set; }
        public string FaceBookUrl { get; set; }
        public string InsagramUrl { get; set; }
        public bool IsActive { get; set; }

    }
}
