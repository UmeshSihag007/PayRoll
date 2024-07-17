using ApwPayroll_Domain.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeLicenses
{
    public class EmployeeLicenseConfiguration:IEntityTypeConfiguration<EmployeeLicense>
    { 
        public void Configure(EntityTypeBuilder<EmployeeLicense> builder)
        {
             

            builder.HasOne(bd => bd.Employee)
                   .WithMany()
                   .HasForeignKey(bd => bd.EmployeeId);

          }
    }
}
