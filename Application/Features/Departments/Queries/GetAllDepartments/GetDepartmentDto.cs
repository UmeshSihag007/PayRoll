using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Departments;
using Couchbase.Core.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Departments.Queries.GetAllDepartments
{
    public class GetDepartmentDto:IMapFrom<Department>
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
