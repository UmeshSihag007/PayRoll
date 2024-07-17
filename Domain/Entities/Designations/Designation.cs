using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Employees.EmployeeDesignations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Designations
{
    public class Designation : BaseAuditEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<EmployeeDesignation> EmployeeDesignations { get; set; } = new List<EmployeeDesignation>();

    }
}
