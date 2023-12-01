using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rat_race;
using RatRaceBLL;

namespace RatRaceWeb.Controllers
{
    public class BetController : Controller
    {
        // GET: BetController

        public static List<Bet> Bets = new List<Bet>() { new Bet() { Money = 2323 } };
        Manager manager;
        public BetController(Manager man)
        {
            manager = man;
        }
        public ActionResult<List<Bet>>  Index()
        {
            return  View(Bets);
        }

        // GET: BetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BetController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
