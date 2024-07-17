using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Menus.MenuTypes;
using ApwPayroll_Domain.Entities.RelationTypes;

namespace ApwPayroll_Application.Contracts.Dtos
{
    public class LookUpDto : IMapFrom<MenuType>, IMapFrom<RelationType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
