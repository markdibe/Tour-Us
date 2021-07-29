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
    public class CategoryRepos : GenericRepos<Category>, ICategoryRepos
    {
        public CategoryRepos(ApplicationDbContext context) : base(context)
        {
        }

        public List<Category> GetCategoriesByActivityId(int activityId)
        {
            return _context.Categories.Include(x => x.CategoryImages).Include(x => x.Activities).ToList();
        }
    }
}
