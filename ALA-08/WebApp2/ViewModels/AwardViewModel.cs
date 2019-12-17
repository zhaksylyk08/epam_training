using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2.ViewModels
{
    public class AwardViewModel
    {
        public int AwardId { get; set; }     

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
