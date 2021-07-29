using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.DAL.Models;

namespace TOUR_US.DAL.Validations
{
    class ActivityValidationAttribute:ValidationAttribute
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        public ActivityValidationAttribute(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ApplicationUser user = value as ApplicationUser;
            IList<string> roles =  _userManager.GetRolesAsync(user).Result;

            if (!roles.Select(x => x.ToLower()).Contains("Host".ToLower()))
            {
                return new ValidationResult("The User Should have the role Of Host");
            }
            return ValidationResult.Success;
        }

    }
}
