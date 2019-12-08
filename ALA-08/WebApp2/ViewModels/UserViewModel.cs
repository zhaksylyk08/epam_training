using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp2.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }    // User

        [DataType(DataType.Date)]

        [Required]
        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        public string ImageUrl { get; set; }

        public int AwardId { get; set; }     // Award

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public string AwardImageUrl{get; set;}
    }
}
