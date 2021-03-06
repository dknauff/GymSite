﻿using GymSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Models.CityModels
{
    public class CityDetail
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public int? StateId { get; set; }

        public virtual ICollection<Gym> Gyms { get; set; }
    }
}
