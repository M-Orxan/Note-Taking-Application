using Microsoft.AspNetCore.Mvc;

namespace Note_Taking_App.Controllers
{
    public class LazimsizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
