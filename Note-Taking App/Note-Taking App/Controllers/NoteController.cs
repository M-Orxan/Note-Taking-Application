using Microsoft.AspNetCore.Mvc;

namespace Note_Taking_App.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
