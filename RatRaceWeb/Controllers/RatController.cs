using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RatRaceWeb.Controllers
{
    public class RatController : Controller
    {
        // GET: RatController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RatController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RatController/Create
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

        // GET: RatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RatController/Edit/5
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

        // GET: RatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RatController/Delete/5
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
