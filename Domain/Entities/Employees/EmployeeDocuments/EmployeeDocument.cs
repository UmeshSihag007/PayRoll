using ApwPayroll_Domain.Entities.Documents;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeDocuments
{
    public class EmployeeDocument
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public string? Code { get; set; }
        public int EmployeeDocumentTypeId { get; set; }
        public EmployeeDocumentType EmployeeDocumentType { get; set; }
        public bool IsActive { get; set; }
        public EmployeeDocument(int documentId, int employeeId, bool isActive, int employeeDocumentTypeId, string? code)
        {
            DocumentId = documentId;
            EmployeeId = employeeId;
            IsActive = isActive;
            EmployeeDocumentTypeId = employeeDocumentTypeId;
            Code = code;
        }
    }
}
