using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.DAL.Models;

namespace TOUR_US.BO.ViewModels
{
    public class ActivityVM
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

        
        public string UserId { get; set; }

        public IFormFileCollection FormFiles { get; set; }

        public virtual List<ActivityImageVM> ActivityImages { get; set; }

      // recently added
        public int CategoryId { get; set; }
        public  virtual Category Category { get; set; }



    }
}
