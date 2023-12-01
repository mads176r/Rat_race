using Microsoft.AspNetCore.Mvc;
using Rat_race;
using RatRaceWeb.Models;
using RatRaceWeb.Models.ViewModels;
using RatRaceWeb.Services;
using System.Diagnostics;

namespace RatRaceWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ManagerService _managerService;

        public HomeController(ILogger<HomeController> logger, ManagerService managerService)
        {
            _logger = logger;
            _managerService = managerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginToPlayer(LoginViewModel model)
        {
            
            string username = model.Username;
            string password = model.Password;

            if (username == null || password == null)
            {
                TempData["ErrorMessage"] = "you can not have empty fields";
                return RedirectToAction("Index");
                //return RedirectToAction("Index", new { ErrorMessage = "you can not have empty fields" });
            }

            Player player = _managerService.Manager.RaceManager.LoginToPlayer(username, password);

            if (player == null)
            {
                TempData["ErrorMessage"] = "PLayer username or login is wrong";
                return RedirectToAction("Index");
                //return RedirectToAction("Index", new { ErrorMessage = "PLayer username or login is wrong" });
            }
            else
            {
                return RedirectToAction("Index", "Bet");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
