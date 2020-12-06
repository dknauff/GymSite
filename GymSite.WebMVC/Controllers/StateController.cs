using GymSite.Data;
using GymSite.Models.StateModels;
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
    public class StateController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.DisplayMenu = "No";

            if (IsAdminUser())
            {
                ViewBag.DisplayMenu = "Yes";
            }

            var service = new StateService();
            var model = service.GetStates();

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
        public ActionResult Create(StateCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new StateService();
            if (service.CreateState(model))
            {
                TempData["SaveResult"] = "State has been sucessfully added!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "State could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            ViewBag.DisplayMenu = "No";

            if (IsAdminUser())
            {
                ViewBag.DisplayMenu = "Yes";
            }

            var service = new StateService();
            var model = service.GetStateById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.DisplayMenu = "No";

            if (IsAdminUser())
            {
                ViewBag.DisplayMenu = "Yes";
            }

            var service = new StateService();
            var detail = service.GetStateById(id);
            var model = new StateEdit
            {
                StateId = detail.StateId,
                Name = detail.Name,
                Abbreviation = detail.Abbreviation
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StateEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.StateId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new StateService();

            if (service.UpdateState(model))
            {
                TempData["SaveResult"] = "State was successfully updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "State could not be updated.");
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

            var service = new StateService();
            var model = service.GetStateById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteState(int id)
        {
            var service = new StateService();

            service.DeleteState(id);

            TempData["SaveResult"] = "The state was deleted.";

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