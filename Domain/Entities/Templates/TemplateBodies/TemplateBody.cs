using ApwPayroll_Domain.common;
using Domain.Models.Templates;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Templates.TemplateBodies
{
    public class TemplateBody : BaseAuditEntity
    {

 
        public int TemplateId { get; set; }
        public Template Template { get; set; }
        public string Body { get; set; }
    }
}
