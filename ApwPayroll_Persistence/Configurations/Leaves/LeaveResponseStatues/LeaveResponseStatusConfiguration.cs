using ApwPayroll_Domain.Entities.Leaves.LeaveResponseStatues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Persistence.Configurations.Leaves.LeaveResponseStatues;

public class LeaveResponseStatusConfiguration : IEntityTypeConfiguration<LeaveResponseStatus>
{
    public void Configure(EntityTypeBuilder<LeaveResponseStatus> builder)
    {
        builder.Property(x => x.LeaveId).IsRequired();
        builder.HasOne(x => x.Leave)
            .WithMany(x=>x.LeaveResponseStatus)
            .HasForeignKey(x => x.LeaveId)
            .IsRequired();
        builder.Property(x => x.ResponseById).IsRequired(false);
        builder.HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.ResponseById)
            .IsRequired(false);

        builder.Property(x => x.ForwordId).IsRequired(false);
        builder.HasOne(x => x.Forword)
            .WithMany()
            .HasForeignKey(x => x.ForwordId)
            .IsRequired(false);
    }
}
