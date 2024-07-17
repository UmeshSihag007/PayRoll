using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.Entities.RelationTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeFamiles
{
    public class EmployeeFamilyConfiguration:IEntityTypeConfiguration<EmployeeFamily>
    {
         
        public void Configure(EntityTypeBuilder<EmployeeFamily> builder)
        { 

            builder.HasOne(bd => bd.RelationType)
                   .WithMany()
                   .HasForeignKey(bd => bd.RelationTypeId);

            builder.HasOne(bd => bd.Employee)
                   .WithMany()
                   .HasForeignKey(bd => bd.EmployeeId);

            builder.Property(bd => bd.Name).IsRequired();
        }
    }
}
