using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.GradeTypeEnums;
using ApwPayroll_Domain.Entities.Employees.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeQualifications
{
    public class EmployeeQualificationConfiguration:IEntityTypeConfiguration<EmployeeQualification>
    { 

        public void Configure(EntityTypeBuilder<EmployeeQualification> builder)
        {
             
            builder.HasOne(bd => bd.Employee)
                   .WithMany()
                   .HasForeignKey(bd => bd.EmployeeId);

            builder.HasOne(bd => bd.Course)
                   .WithMany()
                   .HasForeignKey(bd => bd.CourseId);
        }
    }
}
