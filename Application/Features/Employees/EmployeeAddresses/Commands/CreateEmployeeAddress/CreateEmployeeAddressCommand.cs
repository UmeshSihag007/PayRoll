using ApwPayroll_Domain.Entities.AddressTypes;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeAddresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeAddresses.Commands.CreateEmployeeAddress
{
    public class CreateEmployeeAddressCommand
    {
        public int EmployeeId { get; set; }
        public int AddressTypeId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public int? LocationId { get; set; }
        public int? PinCode { get; set; }
        public bool IsActive { get; set; }
        public string Nationality { get; set; }

    }
}
