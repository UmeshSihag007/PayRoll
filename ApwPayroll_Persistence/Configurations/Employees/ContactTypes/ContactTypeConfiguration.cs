using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Employees.ContactTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace ApwPayroll_Persistence.Configurations.Employees.ContactTypes
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
    {
     

        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }
}
