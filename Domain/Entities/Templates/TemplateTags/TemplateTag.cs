using ApwPayroll_Domain.common;
using Domain.Entities.TemplateTags.TemplateTagTypes;

namespace Domain.Entities.TemplateTags
{
    public class TemplateTag : BaseAuditEntity
    {


        public string Name { get; set; }


        public int TypeId { get; set; }
        public TemplateTagType TemplateTagType { get; set; }
    }
}
