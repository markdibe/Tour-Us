using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class ActivityBO : QueryFilterBO<Activity>
    {
        private readonly ActivityImageBO _image;
        public ActivityBO(IUnitOfWork unit, IGenericRepos<Activity> generic, IMapper mapper, ActivityImageBO image) : base(unit, generic, mapper)
        {
            _image = image;
        }

        public IEnumerable<ActivityVM> GetActivities(QueryFilter query)
        {
            IEnumerable<Activity> Activities = Filter(query);
            IEnumerable<ActivityVM> ActivityList = (from Activity in Activities select Convert(Activity));
            return ActivityList;
        }

       

        public async Task<ActivityVM> Add(ActivityVM Activity)
        {
            try
            {
                Activity activity = Convert(Activity);
                activity = await _uow.ActivityRepos.Create(activity);
                if (Activity.FormFiles.Count() > 0)
                {
                    foreach (IFormFile formfile in Activity.FormFiles)
                    {
                        string imageUrl = await formfile.SaveImage("Activities");
                        ActivityImageVM imageVM = await _image.Add(new ActivityImageVM { ImageTag = formfile.FileName, ImageUrl = imageUrl, ActivityId = activity.Id, FormFile = formfile });
                        Activity.ActivityImages.Add(imageVM);
                    }
                }

                return Convert(activity);
            }
            catch
            {
                return Activity;
            }
        }

        public async Task Delete(int ActivityId)
        {
            await _uow.ActivityRepos.Delete(ActivityId);
        }

        public async Task<ActivityVM> Update(ActivityVM Activity)
        {
            Activity activity = Convert(Activity);
            activity = await _uow.ActivityRepos.Update(activity);
            if (Activity.FormFiles.Count() > 0)
            {
                foreach (IFormFile formfile in Activity.FormFiles)
                {
                    string imageUrl = await formfile.SaveImage("Activities");
                    ActivityImageVM imageVM = await _image.Add(new ActivityImageVM { ImageTag = formfile.FileName, ImageUrl = imageUrl, ActivityId = activity.Id, FormFile = formfile });
                    Activity.ActivityImages.Add(imageVM);
                }
            }
            return Convert(activity);
        }

        public async Task<ActivityVM> GetById(int ActivityId)
        {
            return Convert(await _uow.ActivityRepos.GetById(ActivityId));
        }
        //recently added
        public List<Activity> GetActivityByCategoryId(int categoryId)
        {
            return  _uow.ActivityRepos.GetActivityByCategoryId(categoryId);
        }



        private ActivityVM Convert(Activity Activity)
        {
            return _mapper.Map<ActivityVM>(Activity);
        }

        private Activity Convert(ActivityVM Activity)
        {
            return _mapper.Map<Activity>(Activity);
        }
    }
}
