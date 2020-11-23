using GymSite.Models.ReviewModels;
using GymSite.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymSite.WebMVC.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            var service = CreateReviewService();
            var model = service.GetReviews();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateReviewService();
            if (service.CreateReview(model))
            {
                TempData["SaveResult"] = "Review has been successfully added!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Review could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateReviewService();
            var model = service.GetReviewById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateReviewService();
            var detail = service.GetReviewById(id);
            var model = new ReviewEdit
            {
                ReviewId = detail.ReviewId,
                Stars = detail.Stars,
                Title = detail.Title,
                Text = detail.Text
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ReviewId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateReviewService();

            if (service.UpdateReview(model))
            {
                TempData["SaveResult"] = "Review was successfully updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Review could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateReviewService();
            var model = service.GetReviewById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReview(int id)
        {
            var service = CreateReviewService();

            service.DeleteReview(id);

            TempData["SaveResult"] = "The review was deleted.";

            return RedirectToAction("Index");
        }

        private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);

            return service;
        }
    }
}