using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOUR_US.DAL.Repos;
using TOUR_US.DAL.Services;

namespace TOUR_US.DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        protected readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }



        #region private 

        private IActivityImageRepos activityImageRepos;

        private IActivityRepos activityRepos;

        private ICategoryImageRepos categoryImageRepos;

        private ICategoryRepos categoryRepos;

        private IVoucherActivityRepos voucherActivity;

        private IVoucherImageRepos voucherImageRepos;
        #endregion



        #region public 

        #endregion



        public IActivityImageRepos ActivityImageRepos => activityImageRepos ?? new ActivityImageRepos(_context);

        public IActivityRepos ActivityRepos => activityRepos ?? new ActivityRepos(_context);

        public ICategoryImageRepos CategoryImageRepos => categoryImageRepos ?? new CategoryImageRepos(_context);

        public ICategoryRepos CategoryRepos => categoryRepos ?? new CategoryRepos(_context);

        public IVoucherActivityRepos VoucherActivity => voucherActivity ?? new VoucheredActivityRepos(_context);

        public IVoucherImageRepos VoucherImageRepos => voucherImageRepos ?? new VoucheredImageRepos(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
