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
    public class VoucherActivityBO : QueryFilterBO<VoucheredActivity>
    {
        public VoucherActivityBO(IUnitOfWork unit, IGenericRepos<VoucheredActivity> generic, IMapper mapper) : base(unit, generic, mapper)
        {
        }

        private VoucheredActivity Convert(VoucherActivityVM voucherActivityVM)
        {
            return _mapper.Map<VoucheredActivity>(voucherActivityVM);
        }
        private VoucherActivityVM Convert(VoucheredActivity voucheredActivity)
        {
            return _mapper.Map<VoucherActivityVM>(voucheredActivity);
        }

        public async Task<VoucherActivityVM> Add(VoucherActivityVM voucher)
        {
            VoucheredActivity voucheredActivity = Convert(voucher);
            return Convert(await _uow.VoucherActivity.Create(voucheredActivity));
        }

        public async Task<IEnumerable<VoucheredActivity>> GetVoucherActivityByActivity(int activityId)
        {
            var list = await Task.Run(() => _uow.VoucherActivity.GetAll().Where(x => x.ActivityId == activityId));
            return list;
        }
    }
}
