using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.DAL.Models;
using TOUR_US.DAL.Services;

namespace TOUR_US.DAL.Repos
{
    public class VoucheredImageRepos : GenericRepos<VoucherImage>,IVoucherImageRepos
    {
        public VoucheredImageRepos(ApplicationDbContext context) : base(context)
        {
        }
    }
}
