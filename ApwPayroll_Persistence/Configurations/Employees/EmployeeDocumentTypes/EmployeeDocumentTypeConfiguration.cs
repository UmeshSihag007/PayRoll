using ApwPayroll_Domain.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes
{
    public class EmployeeDocumentTypeConfiguration:IEntityTypeConfiguration <EmployeeDocumentType>
    {
       

        public void Configure(EntityTypeBuilder<EmployeeDocumentType> builder)
        {
            builder.Property(x=>x.Name).IsRequired();
        }
    }
}
