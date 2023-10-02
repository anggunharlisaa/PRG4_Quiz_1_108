using Microsoft.AspNetCore.Mvc;

namespace PRG4_Quiz_1_108.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
