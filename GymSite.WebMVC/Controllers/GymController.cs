using GymSite.Data;
using GymSite.Models.GymModels;
using GymSite.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            ViewBag.DisplayMenu = "No";

            if (IsAdminUser())
            {
                ViewBag.DisplayMenu = "Yes";
            }

            var service = new GymService();
            var model = service.GetGyms();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.DisplayMenu = "No";

            if (IsAdminUser())
            {
                ViewBag.DisplayMenu = "Yes";
            }

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
                TempData["SaveResult"] = "Gym has been successfully added!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Gym could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            ViewBag.DisplayMenu = "No";

            if (IsAdminUser())
            {
                ViewBag.DisplayMenu = "Yes";
            }

            var service = new GymService();
            var model = service.GetGymById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.DisplayMenu = "No";

            if (IsAdminUser())
            {
                ViewBag.DisplayMenu = "Yes";
            }

            var service = new GymService();
            var detail = service.GetGymById(id);
            var model = new GymEdit
            {
                GymId = detail.GymId,
                Name = detail.Name,
                MonthlyCost = detail.MonthlyCost,
                Hours = detail.Hours,
                Description = detail.Description,
                Address = detail.Address,
                Phone = detail.Phone,
                Website = detail.Website,
                Size = detail.Size,
                Equiptment = detail.Equiptment,
                LockerRoom = detail.LockerRoom,
                Classes = detail.Classes,
                PersonalTraining = detail.PersonalTraining,
                AdditionalInfo = detail.AdditionalInfo
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
            ViewBag.DisplayMenu = "No";

            if (IsAdminUser())
            {
                ViewBag.DisplayMenu = "Yes";
            }

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

        public Boolean IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var ctx = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                var s = userManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}