using Microsoft.AspNetCore.Mvc;

namespace Note_Taking_App.Controllers
{
    public class Lazimsiz : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
