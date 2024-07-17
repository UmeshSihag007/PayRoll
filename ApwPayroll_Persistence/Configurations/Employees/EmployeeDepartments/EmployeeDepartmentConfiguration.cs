using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeDepartments
{
    public class EmployeeDepartmentConfiguration:IEntityTypeConfiguration<EmployeeDepartment> 
    { 

        public void Configure(EntityTypeBuilder<EmployeeDepartment> builder)
        {
            builder.HasKey(bd => new { bd.EmployeeId, bd.DepartmentId });
            builder.HasOne(bd => bd.Employee)
                   .WithMany( d => d.EmployeeDepartments)
                   .HasForeignKey(bd => bd.EmployeeId);

            builder.HasOne(bd => bd.Department)
                  .WithMany(d => d.EmployeeDepartments)
                   .HasForeignKey(bd => bd.DepartmentId);

            builder.Property(x=>x.IActive).HasDefaultValue(true);

            builder.HasIndex(x => new { x.DepartmentId, x.EmployeeId });
        }
    }
}
