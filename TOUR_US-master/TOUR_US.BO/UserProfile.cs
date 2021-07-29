using AutoMapper;
using System;
using TOUR_US.BO.ViewModels;
using TOUR_US.DAL.Models;

namespace TOUR_US.BO
{
    public class UserProfile:Profile
    {
        
        public UserProfile()
        {

            CreateMap<CategoryVM, Category>().ReverseMap();
            CreateMap<CategoryImageVM, CategoryImage>().ReverseMap();
            CreateMap<ActivityImageVM, ActivityImage>().ReverseMap();
            CreateMap<Activity, ActivityVM>().ReverseMap();
        }
    }
}
