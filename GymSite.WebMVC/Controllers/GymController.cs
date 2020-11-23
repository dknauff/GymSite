using GymSite.Models.GymModels;
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

        public ActionResult Details(int id)
        {
            var service = new GymService();
            var model = service.GetGymById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new GymService();
            var detail = service.GetGymById(id);
            var model = new GymEdit
            {
                GymId = detail.GymId,
                MembershipPrice = detail.MembershipPrice,
                Description = detail.Description,
                Address = detail.Address,
                Phone = detail.Phone,
                Website = detail.Website,
                Size = detail.Size
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GymEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GymId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new GymService();

            if (service.UpdateGym(model))
            {
                TempData["SaveResult"] = "Gym was successfully updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Gym could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new GymService();
            var model = service.GetGymById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGym(int id)
        {
            var service = new GymService();

            service.DeleteGym(id);

            TempData["SaveResult"] = "The gym was deleted.";

            return RedirectToAction("Index");
        }
    }
}