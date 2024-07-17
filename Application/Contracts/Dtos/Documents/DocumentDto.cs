using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Contracts.Dtos.Documents
{
    public class DocumentDto : IMapFrom<Document>
    {
        public string Tittle { get; set; }
        public string Url { get; set; }
    }
}
