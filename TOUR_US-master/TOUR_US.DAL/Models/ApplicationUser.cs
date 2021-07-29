using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TOUR_US.DAL.Models
{
   public class ApplicationUser:IdentityUser
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Please do not exceed 200 characters!")]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        [StringLength(300)]
        public string ImageUrl { get; set; }

        [DataType(DataType.ImageUrl)]
        [StringLength(300)]
        public string VideoUrl { get; set; }


        [Required]
        public bool IsActive { get; set; }  

        [Required]
        [DataType(DataType.Text)]
        [StringLength(6)]
        public string Gender { get; set; }

        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Tags { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        public int Age { get; set; }



        public virtual ICollection<Activity> Activities { get; set; }

        public virtual ICollection<VoucheredActivity> VoucheredActivities { get; set; }


    }
}
