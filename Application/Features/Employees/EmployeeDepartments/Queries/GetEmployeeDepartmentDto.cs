using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Departments;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeDepartments.Queries
{
    public class GetEmployeeDepartmentDto : IMapFrom<Department>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
