using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR_US.BO.ViewModels
{
    public class CategoryVM
    {
        
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

        public string UserId { get; set; }


        public IFormFileCollection FormFiles { get; set; }


        public virtual ICollection<CategoryImageVM> CategoryImageVMs { get; set; }

        //recently added

        public virtual ICollection<ActivityVM> ActivityVMs { get; set; }
    }
}
