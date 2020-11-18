using GymSite.Models.Gym;
using GymSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymSite.WebMVC.Controllers
{
    [Authorize]
    public class GymController : Controller
    {
        // GET: Gym
        public ActionResult Index()
        {
            var service = new GymService();
            var model = service.GetGyms();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GymCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new GymService();
            if (service.CreateGym(model))
            {
                TempData["SaveResult"] = "Gym has been successfully added!.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Gym could not be added.");
            return View(model);
        }
    }
}