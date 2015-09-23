using Microsoft.AspNet.Mvc;

namespace playgroud_asp_schedule.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult index()
        {
            return View();
        }

        public IActionResult about()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult error()
        {
            return View("~/Views/Shared/error.cshtml");
        }
    }
}
