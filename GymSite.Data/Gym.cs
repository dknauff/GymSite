using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Data
{
    public class Gym
    {
        [Key]
        public int GymId { get; set; }
        public string Name { get; set; }
        public decimal MembershipPrice { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        //public int CityId { get; set; }
        public string Website { get; set; }
        public string Size { get; set; }
        //[Display(Name = "Multiple Locations")]
        //public bool HasMultipleLocations { get; set; }
        //[Display(Name = "Classes")]
        //public bool HasClasses { get; set; }
        //[Display(Name = "Personal Training")]
        //public bool HasPersonalTraining { get; set; }
    }
}
