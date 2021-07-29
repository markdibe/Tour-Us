using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.BO.Attributes;

namespace TOUR_US.BO.ViewModels
{
    public class CategoryImageVM
    {
        public int CategoryImageId { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [StringLength(300)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500)]
        public string ImageTag { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensionFile(".jpg,.bmp,.PNG,.EPS,.gif,.TIFF,.tif,.jfif")]
        public IFormFile FormFile { get; set; }
    }
}
