﻿using GymSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Models.StateModels
{
    public class StateDetail
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
