using Microsoft.AspNetCore.Mvc;

namespace ApwPayrollWebApp.Controllers.Settings
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LeaveType()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Holiday()
        {
            return View();
        }
    }
}
