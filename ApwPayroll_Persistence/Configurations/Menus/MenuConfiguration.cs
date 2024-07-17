using ApwPayroll_Domain.Entities.Menus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Menus
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {


            builder.Property(m => m.IsActive).HasDefaultValue(true);


            builder.HasOne(m => m.MenuType)
                   .WithMany()
                   .HasForeignKey(m => m.MenuTypeId);

            builder.HasOne(m => m.Parent)
                   .WithMany()
                   .HasForeignKey(m => m.ParentId);

        }
    }
}
