using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.LocationTypes;

namespace ApwPayroll_Domain.Entities.Locations
{
    public class Location : BaseAuditEntity
    {
        public string Name { get; set; }
        public LocationTypeEnum LocationType { get; set; }
        public int? ParentId { get; set; }
        public Location? Parent { get; set; }
    }
}
