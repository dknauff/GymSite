using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Models.GymModels
{
    public class GymCreate
    {
        [Required]
        public string Name { get; set; }
        [Display(Name= "Cost/Month")]
        public string MonthlyCost { get; set; }
        public string Hours { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Size { get; set; }
        public string Equipment { get; set; }
        [Display(Name = "Locker Room Info")]
        public string LockerRoom { get; set; }
        [Display(Name = "Class Info")]
        public string Classes { get; set; }
        [Display(Name = "Personal Training Info")]
        public string PersonalTraining { get; set; }
        [Display(Name = "Additional Info")]
        public string AdditionalInfo { get; set; }

        public int? CityId { get; set; }
    }
}
