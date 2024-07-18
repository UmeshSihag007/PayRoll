namespace ApwPayrollWebApp.Views.Documents
{
    public class DocumentViewModel
    {
        public int EmployeeId { get; set; }
 
        public List<DocumentTypeViewModel> DocumentTypes { get; set; }
    }

    public class DocumentTypeViewModel
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public IFormFile File { get; set; }
        public string Number { get; set; }  
    }

}
