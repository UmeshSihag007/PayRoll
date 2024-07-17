using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeLanguages
{
    public class EmployeeLanguageConfiguration:IEntityTypeConfiguration<EmployeeLanguage>
    { 

        public void Configure(EntityTypeBuilder<EmployeeLanguage> builder)
        {
            
            builder.HasOne(bd => bd.Employee)
                   .WithMany()
                   .HasForeignKey(bd => bd.EmployeeId);
 ;
        }
    }
}
