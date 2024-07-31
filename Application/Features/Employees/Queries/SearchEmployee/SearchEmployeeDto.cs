using ApwPayroll_Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.Queries.SearchEmployee
{
    public class SearchEmployeeDto
    {
        public string? Name  { get; set; }
        [Email]
        public string? Email { get; set; }

        [MobileNumber]
        public Int64? MobileNumber { get; set; }

        public DateTime? DateOfJoining { get; set; }

        public int BranchId { get; set; }
        public int? DesignationId { get; set; }  
        public  int? DepartmentId { get; set; }
        public string ? EmployeeCode { get; set;}

        public  string? PanNumber { get; set; } 
        
 
    }
}
