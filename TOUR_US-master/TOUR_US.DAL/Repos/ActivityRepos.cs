using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.DAL.Models;
using TOUR_US.DAL.Services;

namespace TOUR_US.DAL.Repos
{
    public class ActivityRepos : GenericRepos<Activity>,IActivityRepos
    {
        public ActivityRepos(ApplicationDbContext context) : base(context)
        {
        }
        

        public List<Activity> GetActivityByCategoryId(int categoryId)
        {
            return _context.Activities
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.Category)
                .Include(x => x.ActivityImages).ToList();
        }
    }
}
