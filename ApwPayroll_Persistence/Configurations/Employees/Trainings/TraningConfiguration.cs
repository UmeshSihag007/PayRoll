using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Domain.Entities.Employees.Trainings
{
    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    { 
        public void Configure(EntityTypeBuilder<Training> builder)
        {

            builder.HasOne(bd => bd.Employee)
                   .WithMany()
                   .HasForeignKey(bd => bd.EmployeeId);

            builder.HasOne(bd => bd.Certificate)
                   .WithMany()
                   .HasForeignKey(bd => bd.CertificateId);
        }
    }
}
