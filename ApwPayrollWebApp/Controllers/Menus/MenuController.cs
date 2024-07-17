using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Menus
{
    public class MenuController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
    }
}
