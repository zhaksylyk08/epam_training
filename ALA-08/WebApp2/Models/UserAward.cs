using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2.Models
{
    public class UserAward
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int AwardId { get; set; }
        public Award Award { get; set; }
    }
}
