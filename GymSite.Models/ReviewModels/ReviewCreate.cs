﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Models.ReviewModels
{
    public class ReviewCreate
    {
        [Range(1,5, ErrorMessage = "1-5 Stars")]
        public int Stars { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public int GymId { get; set; }
    }
}
