using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Documents;
using Domain.Models.Templates;

namespace Domain.Entities.Templates.TemplateDocuments
{
    public class TemplateDocument 
    {

        public int DocumentId { get; set; }
        public Document Document { get; set; }

        public int TemplateId { get; set; }
        public Template Template { get; set; }

        public TemplateDocument(int documentId, int templateId)
        {

            DocumentId = documentId;
            TemplateId = templateId;

        }
    }
}
