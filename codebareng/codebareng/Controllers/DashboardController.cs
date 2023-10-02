using Microsoft.AspNetCore.Mvc;

namespace codebareng.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
