using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Menus.MenuTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Menus
{
    public class Menu:BaseAuditEntity
    {
        public string Name { get; set; }    
        public string Url { get; set; }
        public string Icon { get; set; }
        public  bool IsActive { get; set; }
        public int? MenuTypeId { get; set; }
        public MenuType? MenuType { get; set; }
        public int? ParentId { get; set; }
        public  Menu? Parent {  get; set; }

    }
}
