using ApwPayroll_Domain.common;

namespace ApwPayroll_Domain.Entities.Menus.MenuTypes;

public class MenuType : BaseAuditEntity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
