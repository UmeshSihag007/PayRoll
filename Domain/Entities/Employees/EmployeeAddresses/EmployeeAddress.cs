using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.AddressTypes;
using ApwPayroll_Domain.Entities.Locations;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeAddresses
{
    public class EmployeeAddress : BaseAuditEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int AddressTypeId { get; set; }
        public AddressType AddressType { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        public int? PinCode { get; set; }
        public bool IsActive { get; set; }
        public string? Nationality { get; set; }

    }
}
