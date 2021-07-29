using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR_US.BO.ViewModels
{
    public class ActivityImageVM
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [StringLength(300)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500)]
        public string ImageTag { get; set; }

        [Required]
        public int ActivityId { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
