﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Award
    {
        public int AwardId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public IList<UserAward> UserAwards { get; set; }
    }
}
