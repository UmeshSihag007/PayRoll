﻿using ApwPayroll_Domain.Entities.Holidays.HolidayTypeRoles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Holidays.HolidayTypeRoles;

public class HolidayTypeRoleConfiguration : IEntityTypeConfiguration<HolidatTypeRole>
{
    public void Configure(EntityTypeBuilder<HolidatTypeRole> builder)
    {
        builder.HasKey(e => e.Id);


        builder.Property(e => e.HolidayId)
            .IsRequired();

        builder.Property(e => e.LocationId)
            .IsRequired();

        builder.Property(e => e.BranchId)
            .IsRequired();

        builder.HasOne(bd => bd.Holiday)
               .WithMany()
               .HasForeignKey(bd => bd.HolidayId)
               .IsRequired(true);



        builder.HasOne(e => e.Location)
            .WithMany()
            .HasForeignKey(x => x.LocationId)
          .IsRequired();

        builder.HasOne(e => e.Branch)
            .WithMany()
            .HasForeignKey(e => e.BranchId)
        .IsRequired();

    }

}


