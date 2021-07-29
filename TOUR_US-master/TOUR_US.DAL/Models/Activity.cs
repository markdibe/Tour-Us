using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.DAL.Validations;

namespace TOUR_US.DAL.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [StringLength(500)]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500)]
        public string Header { get; set; }


        [DataType(DataType.MultilineText)]
        [StringLength(2000)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]

        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        [Required]
        public ApplicationUser CreatedBy { get; set; }

        //recently added

        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [DataType(DataType.Text)]
        [StringLength(200)]
        public string Region { get; set; }

        [DataType(DataType.Text)]
        [StringLength(15)]
        public string Price { get; set; }




        public virtual ICollection<ActivityImage> ActivityImages { get; set; }

        public virtual ICollection<VoucheredActivity> Vouchereds { get; set; }

    }
}
