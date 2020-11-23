using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Models.GymModels
{
    public class GymListItem
    {
        public int GymId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Membership Price")]
        public decimal MembershipPrice { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Size { get; set; }
    }
}
