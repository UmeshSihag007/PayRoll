using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Departments;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Departments.Queries
{
    public class GetDepartmentDto : IMapFrom<Department>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
