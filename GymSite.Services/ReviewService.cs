using GymSite.Data;
using GymSite.Models.ReviewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Services
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Reviews.Select(e => new ReviewListItem
                {
                    ReviewId = e.ReviewId,
                    OwnerId = _userId,
                    Stars = e.Stars,
                    Title = e.Title,
                    Text = e.Text,
                    GymId = e.GymId
                });

                return query.ToArray();
            }
        }

        public bool CreateReview(ReviewCreate model)
        {
            var entity = new Review()
            {
                Stars = model.Stars,
                Title = model.Title,
                Text = model.Text,
                OwnerId = _userId,
                GymId = model.GymId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ReviewDetail GetReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => e.ReviewId == id);
                return new ReviewDetail
                {
                    ReviewId = entity.ReviewId,
                    Stars = entity.Stars,
                    Title = entity.Title,
                    Text = entity.Text,
                    GymId = entity.GymId
                };
            }
        }

        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => e.ReviewId == model.ReviewId && e.OwnerId == _userId);

                entity.Stars = model.Stars;
                entity.Title = model.Title;
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reviews.Single(e => e.ReviewId == reviewId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
