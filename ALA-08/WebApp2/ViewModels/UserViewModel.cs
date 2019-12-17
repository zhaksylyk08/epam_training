using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp2.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Range(0, 150)]
        public int Age { get; set; }

        public string ImageUrl { get; set; }


    }
}
