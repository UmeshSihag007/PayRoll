using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.RelationTypes;

namespace ApwPayroll_Domain.Entities.Employees.EmergencyContacts
{
    public class EmergencyContact : BaseAuditEntity
    {
        public string Name { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int? RelationTypeId { get; set; }
        public RelationType? RelationType { get; set; }

        public string? Email { get; set; }
         
        public Int64? MobileNumber { get; set; }
        public Int64? WhatsAppNumber { get; set; }

    }
}
