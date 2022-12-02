using Microsoft.AspNetCore.Mvc;
using Note_Taking_App.Models;
using System.Diagnostics;

namespace Note_Taking_App.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult Error()
        {
            return View();
        }
    }
}