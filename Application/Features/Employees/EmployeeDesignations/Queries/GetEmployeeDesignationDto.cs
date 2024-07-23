using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Designations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeDesignations.Queries
{
    public class GetEmployeeDesignationDto:IMapFrom<Designation>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
