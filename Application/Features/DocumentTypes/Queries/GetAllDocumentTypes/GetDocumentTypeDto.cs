using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Application.Contracts.Dtos;
using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.DocumentTypes.Queries.GetAllDocumentTypes
{
    public class GetDocumentTypeDto : BaseDto, IMapFrom<DocumentType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
