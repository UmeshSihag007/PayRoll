using ApwPayroll_Persistence.Configurations.Templates.TemplateTags.TemplateTagTypes;
using Domain.Entities.TemplateTags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApwPayroll_Persistence.Configurations.Templates.TemplateTags
{
    public class TemplateTagConfigurations : IEntityTypeConfiguration<TemplateTag>
    {
        public void Configure(EntityTypeBuilder<TemplateTag> builder)
        {

            builder.HasOne(nl => nl.TemplateTagType)
                   .WithMany()
                   .HasForeignKey(nl => nl.TypeId)
                   .IsRequired();
        }
    }
}
