using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Models.CityModels
{
    public class CityCreate
    {
        public string Name { get; set; }

        public int? StateId { get; set; }
    }
}
