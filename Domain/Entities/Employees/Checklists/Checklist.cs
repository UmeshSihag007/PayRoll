using ApwPayroll_Domain.common;

namespace ApwPayroll_Domain.Entities.Employees.Checklists
{
    public class Checklist : BaseAuditEntity
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public Checklist Parent { get; set; }
    }

}
