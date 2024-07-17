using ApwPayroll_Domain.common;
using Domain.Entities.Templates.TemplateBodies;
using Domain.Entities.Templates.TemplateDocuments;
using Domain.Entities.Templates.TemplateTypes;

namespace Domain.Models.Templates
{
    public class Template : BaseAuditEntity
    {
        public string Subject { get; set; }

        public int TypeId { get; set; }
        public TemplateType TemplateType { get; set; }
        public List<TemplateDocument> TemplateDocument { get; set; }
        public TemplateBody TemplateBody { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
