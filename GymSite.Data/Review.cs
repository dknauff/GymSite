using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public Guid OwnerId { get; set; }
        public int Stars { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public int GymId { get; set; }
        internal Gym Gym { get; set; }
    }
}
