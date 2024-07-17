using Domain.Models.Templates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Templates
{
    public class TemplateConfigurations : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {

            builder.HasOne(nl => nl.TemplateType)
                   .WithMany()
                   .HasForeignKey(nl => nl.TypeId)
                   .IsRequired();
        }
    }
}
