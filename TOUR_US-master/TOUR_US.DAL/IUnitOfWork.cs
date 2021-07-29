using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.DAL.Services;

namespace TOUR_US.DAL
{
    public interface IUnitOfWork
    {
        IActivityImageRepos ActivityImageRepos { get; }
        IActivityRepos ActivityRepos { get; }

        ICategoryImageRepos CategoryImageRepos { get; }

        ICategoryRepos CategoryRepos { get;  }
        IVoucherActivityRepos VoucherActivity { get; }

        IVoucherImageRepos VoucherImageRepos { get; }


    }
}
