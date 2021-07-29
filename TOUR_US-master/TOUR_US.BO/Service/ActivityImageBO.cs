using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.BO.ViewModels;
using TOUR_US.DAL;
using TOUR_US.DAL.Models;
using TOUR_US.DAL.Services;

namespace TOUR_US.BO.Service
{
    public class ActivityImageBO : QueryFilterBO<ActivityImage>
    {
        public ActivityImageBO(IUnitOfWork unit, IGenericRepos<ActivityImage> generic, IMapper mapper) : base(unit, generic, mapper)
        {

        }

        public IEnumerable<ActivityImageVM> GetCategories(QueryFilter query)
        {
            IEnumerable<ActivityImage> Categories = Filter(query);
            IEnumerable<ActivityImageVM> CategoryImageList = (from CategoryImage in Categories select Convert(CategoryImage));
            return CategoryImageList;
        }

        public async Task<ActivityImageVM> Add(ActivityImageVM activityImage)
        {
            try
            {
                string imageUrl = await activityImage.FormFile.SaveImage("Categories");
                ActivityImage activity = Convert(activityImage);
                activity.ImageUrl = imageUrl;
                activity = await _uow.ActivityImageRepos.Create(activity);
                return Convert(activity);
            }
            catch
            {
                return activityImage;
            }
        }

        public async Task Delete(int CategoryImageId)
        {
            await _uow.CategoryImageRepos.Delete(CategoryImageId);
        }

        public async Task<ActivityImageVM> Update(ActivityImageVM activityImage)
        {
            string imageUrl = await activityImage.FormFile.SaveImage("Activities");
            ActivityImage activity= Convert(activityImage);
            activity.ImageUrl = imageUrl;
            activity = await _uow.ActivityImageRepos.Update(activity);
            return Convert(activity);
        }

        public async Task<ActivityImageVM> GetById(int CategoryImageId)
        {
            return Convert(await _uow.ActivityImageRepos.GetById(CategoryImageId));
        }

        private ActivityImageVM Convert(ActivityImage CategoryImage)
        {
            return _mapper.Map<ActivityImageVM>(CategoryImage);
        }

        private ActivityImage Convert(ActivityImageVM CategoryImage)
        {
            return _mapper.Map<ActivityImage>(CategoryImage);
        }

    }
}
