using ApwPayroll_Domain.common;

namespace ApwPayroll_Domain.Entities.RelationTypes
{
    public class RelationType : BaseAuditEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
