using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocuments;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeDocuments.Queries.GetEmployeeDocumentById
{
    public class GetEmployeeDocumentDto:IMapFrom<EmployeeDocument>
    {
        public int Id {  get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeDocumentTypeId { get; set; }
        public EmployeeDocumentType EmployeeDocumentType { get; set; }
        public bool IsActive { get; set; }
    }
}
