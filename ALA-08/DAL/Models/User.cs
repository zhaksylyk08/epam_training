using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<UserAward> UserAwards { get; set; }
    }
}
