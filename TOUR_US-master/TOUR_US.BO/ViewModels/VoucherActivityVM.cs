using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR_US.BO.ViewModels
{
   public class VoucherActivityVM
    {
        public int VoucherId { get; set; }
        public DateTime VoucherDate { get; set; }
       
        public string UserId { get; set; }
       

        
        public int ActivityId { get; set; }

       

        [Range(0, 5)]
        public float Rate { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(2000)]
        public string ReviewDescription { get; set; }
        [StringLength(500)]
        [DataType(DataType.Text)]
        public string ReviewTitle { get; set; }


        public bool IsValid { get; set; }

    }
}
