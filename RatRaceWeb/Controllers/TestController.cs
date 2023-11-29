using Microsoft.AspNetCore.Mvc;
using RatRaceWeb.Models;
using System.Diagnostics;

namespace RatRaceWeb.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        public IActionResult Test()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult YourCustomMethod()
        {
            ViewData["Title"] = "Your Custom Method Page";
            return View();
        }
    }
}
