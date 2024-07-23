using ApwPayroll_Domain.Entities.Employees.EmployeeExperiences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Persistence.Configurations.Employees.EmployeeExperiences
{
    public class EmployeeExperienceConfiguration : IEntityTypeConfiguration<EmployeeExperience>
    {
        public void Configure(EntityTypeBuilder<EmployeeExperience> builder)
        {
            builder.HasOne(e => e.Employee)
         .WithMany(x => x.EmployeeExperience)
         .HasForeignKey(e => e.EmployeeId);
        }
    }
}
