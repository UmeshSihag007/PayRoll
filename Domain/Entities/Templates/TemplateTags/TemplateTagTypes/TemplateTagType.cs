using ApwPayroll_Domain.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TemplateTags.TemplateTagTypes
{
    public class TemplateTagType:BaseAuditEntity
    {
        
        public string Name { get; set; }
        public  bool IsActive {  get; set; }
    }
}
