using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocuments;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeDocuments.Commands.CreateEmployeeDocuments
{
    public class CreateEmployeeDocumentDto : IMapFrom<EmployeeDocument>
    {
        public string? Code { get; set; }
        public IFormFile Document { get; set; }
        public int EmployeeDocumentTypeId { get; set; }
       
    }
}
