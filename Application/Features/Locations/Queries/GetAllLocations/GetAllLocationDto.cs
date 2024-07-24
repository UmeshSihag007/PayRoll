using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.common.Enums.LocationTypes;
using ApwPayroll_Domain.Entities.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Locations.Queries.GetAllLocations
{
    public class GetAllLocationDto:IMapFrom<Location>
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public LocationTypeEnum LocationType { get; set; }
        public int? ParentId { get; set; }
        public GetAllLocationDto? Parent { get; set; }
    }
}
