using ApwPayroll_Domain.common;

namespace ApwPayroll_Domain.Entities.Employees.Trainings
{
    public class Training : BaseAuditEntity
    {
        public string Name { get; set; }
        public int CertificateId { get; set; }
        public Certificate Certificate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
