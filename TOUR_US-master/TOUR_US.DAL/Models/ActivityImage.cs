using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR_US.DAL.Models
{
   public  class ActivityImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [StringLength(300)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500)]
        public string ImageTag { get; set; }

        [ForeignKey(nameof(Activity))]
        [Required]
        public int ActivityId { get; set; }

        public Activity Activity { get; set; }

        public virtual ICollection<ActivityImage> ActivityImages { get; set; }
    }
}
