using GymSite.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymSite.WebMVC.Controllers
{
    [Authorize]
    public class RatingsController : Controller
    {

        // GET: Rating
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetRatings(int gymId, double rank, string comment)
        {
            var rating = new Rating
            {
                GymId = gymId,
                Rank = rank,
                Comment = comment,
                UserId = User.Identity.GetUserId()
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(rating);
                ctx.SaveChanges();
            }

            return RedirectToAction("Details", "Gym", new { id = gymId });
        }
    }
}