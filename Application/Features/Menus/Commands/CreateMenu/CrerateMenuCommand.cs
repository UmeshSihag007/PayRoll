using ApwPayroll_Domain.Entities.Menus;
using ApwPayroll_Domain.Entities.Menus.MenuTypes;
using ApwPayroll_Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Menus.Commands.CreateMenu
{
    public class CrateMenuCommand:IRequest<Result<int>>
    {
        public string Name { get; set; }
        public IFormFile Url { get; set; }
        public IFormFile Icon { get; set; }
        public bool IsActive { get; set; }
        public int? MenuTypeId { get; set; }
        public int? ParentId { get; set; }
    }

}
