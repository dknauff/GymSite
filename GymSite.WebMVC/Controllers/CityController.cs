using GymSite.Models.CityModels;
using GymSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymSite.WebMVC.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        public ActionResult Index()
        {
            var service = new CityService();
            var model = service.GetCities();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new CityService();
            if (service.CreateCity(model))
            {
                TempData["SaveResult"] = "State has been sucessfully added!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "City could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = new CityService();
            var model = service.GetCityById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new CityService();
            var detail = service.GetCityById(id);
            var model = new CityEdit
            {
                CityId = detail.CityId,
                Name = detail.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CityEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CityId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new CityService();

            if (service.UpdateCity(model))
            {
                TempData["SaveResult"] = "City was successfully updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "City could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new CityService();
            var model = service.GetCityById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCity(int id)
        {
            var service = new CityService();

            service.DeleteCity(id);

            TempData["SaveResult"] = "The city was deleted.";

            return RedirectToAction("Index");
        }
    }
}