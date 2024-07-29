using ApwPayroll_Domain.Entities.Employees.EmergencyContacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Employees.EmergencyContacts
{
    public class EmergencyContactConfiguration : IEntityTypeConfiguration<EmergencyContact>
    {
        public void Configure(EntityTypeBuilder<EmergencyContact> builder)
        {
            builder.HasOne(bd => bd.Employee)
    .WithMany(x=>x.EmergencyContact)
    .HasForeignKey(bd => bd.EmployeeId);


            builder.HasOne(bd => bd.RelationType)
   .WithMany()
   .HasForeignKey(bd => bd.RelationTypeId);
        }
    }
}
