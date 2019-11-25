using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
    }
}
