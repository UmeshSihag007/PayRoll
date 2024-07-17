using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocuments;

namespace ApwPayroll_Domain.Entities.Documents
{
    public class Document : BaseAuditEntity
    {
        public string Tittle { get; set; }
        public string Url { get; set; }
        public int  TypeId { get; set; }    
        public DocumentType DocumentType { get; set; }

        public List<EmployeeDocument> EmployeeDocuments { get; set; } = new List<EmployeeDocument>();

        public Document()
        {

        }
    }
}
