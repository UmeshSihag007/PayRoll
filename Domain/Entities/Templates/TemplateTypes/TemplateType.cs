using ApwPayroll_Domain.common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Templates.TemplateTypes
{
    public class TemplateType:BaseAuditEntity
    { 
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
