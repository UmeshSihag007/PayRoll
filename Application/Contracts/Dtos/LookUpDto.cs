using ApwPayroll_Application.Common.Mappings;
 
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using ApwPayroll_Domain.Entities.Menus.MenuTypes;
using ApwPayroll_Domain.Entities.RelationTypes;

namespace ApwPayroll_Application.Contracts.Dtos
{
  
    public class LookUpDto : IMapFrom<MenuType>, IMapFrom<RelationType>,IMapFrom<EmployeeDocumentType>,IMapFrom<Bank>,IMapFrom<Branch>
 
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
