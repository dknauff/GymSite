using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Data
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public int? StateId { get; set; }
        internal State State { get; set; }

        public virtual ICollection<Gym> Gyms { get; set; }
    }
}
