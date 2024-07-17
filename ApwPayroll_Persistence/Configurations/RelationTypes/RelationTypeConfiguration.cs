using ApwPayroll_Domain.Entities.RelationTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.RelationTypes
{
    public class RelationTypeConfiguration : IEntityTypeConfiguration<RelationType>
    {


        public void Configure(EntityTypeBuilder<RelationType> builder)
        {
            builder.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }
}
