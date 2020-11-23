using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Models.ReviewModels
{
    public class ReviewListItem
    {
        public int ReviewId { get; set; }
        public Guid OwnerId { get; set; }
        public int Stars { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public int GymId { get; set; }
    }
}
