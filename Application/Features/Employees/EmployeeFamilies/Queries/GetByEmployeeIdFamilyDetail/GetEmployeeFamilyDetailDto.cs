using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Domain.Entities.RelationTypes;

namespace ApwPayroll_Application.Features.Employees.EmployeeFamilies.Queries.GetByEmployeeIdFamilyDetail
{
    public class GetEmployeeFamilyDetailDto : IMapFrom<EmployeeFamily>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RelationTypeId { get; set; }
        public RelationType RelationType { get; set; }
        public DateTime DOB { get; set; }
        public GenderEnum Gender { get; set; }
        public int EmployeeId { get; set; }
        public bool IsActive { get; set; }
    }
}
