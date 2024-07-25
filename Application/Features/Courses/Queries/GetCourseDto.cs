using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Employees.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Courses.Queries
{
    public class GetCourseDto : IMapFrom<Course>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
