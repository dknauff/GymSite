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
        public string MonthlyCost { get; set; }
        public string Hours { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Size { get; set; }
        public string Equipment { get; set; }
        public string LockerRoom { get; set; }
        public string Classes { get; set; }
        public string PersonalTraining { get; set; }
        public string AdditionalInfo { get; set; }

        public int? CityId { get; set; }
        internal City City { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
