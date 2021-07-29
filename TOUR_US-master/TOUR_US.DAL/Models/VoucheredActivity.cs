using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR_US.DAL.Models
{
    public class VoucheredActivity
    {
        [Key]
        public int VoucherId { get; set; }
        public DateTime VoucherDate{ get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public ApplicationUser VoucherBy { get; set; }

        [ForeignKey(nameof(Activity))]
        public int ActivityId { get; set; }

        public Activity Activity { get; set; }

        [Range(0,5)]
        public float Rate { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(2000)]
        public string ReviewDescription { get; set; }
        [StringLength(500)]
        [DataType(DataType.Text)]
        public string ReviewTitle { get; set; }


        public bool IsValid { get; set; }


        public virtual ICollection<VoucherImage> VoucherImages { get; set; }
    
    }
}
