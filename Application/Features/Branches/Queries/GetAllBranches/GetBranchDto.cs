using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Banks.Branches;

namespace ApwPayroll_Application.Features.Branches.Queries.GetAllBranches;

public class GetBranchDto : IMapFrom<Branch>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
