using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR_US.DAL.Models
{
    public class VoucherImage
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.ImageUrl)]
        [Required]
        [StringLength(300)]
        public string ImageUrl { get; set; }

        [Required]
        [ForeignKey(nameof(VoucheredActivity))]
        public int VoucherActivityId { get; set; }
        public VoucheredActivity VoucheredActivity { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Order { get; set; }

        public bool IsActive { get; set; }


    }
}
