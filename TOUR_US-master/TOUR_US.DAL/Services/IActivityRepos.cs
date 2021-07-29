using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.DAL.Models;

namespace TOUR_US.DAL.Services
{
    public interface IActivityRepos :IGenericRepos<Activity>
    {
        //recently added
        List<Activity> GetActivityByCategoryId(int categoryId);
    }
}
