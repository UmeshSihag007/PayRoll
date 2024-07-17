using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.ContactTypes;
using ApwPayroll_Domain.Entities.Employees.EmployeeContacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Persistence.Configurations.Employees.EmployeeContacts
{
    public class EmployeeContactConfiguration : IEntityTypeConfiguration<EmployeeContact>
    { 
        public void Configure(EntityTypeBuilder<EmployeeContact> builder)
        {

            builder.HasOne(bd => bd.Employee)
                   .WithMany()
                   .HasForeignKey(bd => bd.EmployeeId);

            builder.HasOne(bd => bd.ContactType)
                   .WithMany()
                   .HasForeignKey(bd => bd.ContactTypeId);
        }
    }
}
