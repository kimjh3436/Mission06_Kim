using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Kim.Models;

namespace Mission06_Kim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Movie { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
