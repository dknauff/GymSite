using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Data
{
    public class Rating
    {
        [Required]
        [Key]
        public int RatingId { get; set; }
        [Display(Name = "User")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        [Required]
        [Display(Name = "Gym")]
        public int GymId { get; set; }
        [ForeignKey("GymId")]
        public virtual Gym Gym { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        [Range(1, 5)]
        [Display(Name = "Stars")]
        public double Rank { get; set; }
        [Display(Name = "Review")]
        public string Comment { get; set; }
    }
}
