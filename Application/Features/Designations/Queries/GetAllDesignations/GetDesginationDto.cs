using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Designations;

namespace ApwPayroll_Application.Features.Designations.Queries.GetAllDesignations
{
    public class GetDesignationDto : IMapFrom<Designation>
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
