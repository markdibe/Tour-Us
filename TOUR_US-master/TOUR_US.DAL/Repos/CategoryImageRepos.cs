using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.DAL.Models;
using TOUR_US.DAL.Services;

namespace TOUR_US.DAL.Repos
{
    public class CategoryImageRepos : GenericRepos<CategoryImage>, ICategoryImageRepos
    {
        public CategoryImageRepos(ApplicationDbContext context) : base(context)
        {
        }

    }
}
