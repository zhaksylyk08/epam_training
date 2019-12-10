using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class UserAward
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int AwardId { get; set; }
        public Award Award { get; set; }
    }
}
