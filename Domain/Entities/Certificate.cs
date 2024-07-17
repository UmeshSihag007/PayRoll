using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Documents;

namespace ApwPayroll_Domain.Entities
{
    public class Certificate : BaseAuditEntity
    {
        public string Name { get; set; }
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public bool IsActive { get; set; }
    }
}
