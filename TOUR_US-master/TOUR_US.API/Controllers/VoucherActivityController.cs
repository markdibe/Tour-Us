using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOUR_US.BO.Service;
using TOUR_US.BO.ViewModels;

namespace TOUR_US.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherActivityController : ControllerBase
    {

        private readonly VoucherActivityBO _voucher;

        public VoucherActivityController(VoucherActivityBO voucher)
        {
            _voucher = voucher;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<VoucherActivityVM>> GetVoucherActivityByActivity([FromQuery] int activityId)
        {
            return Ok(await _voucher.GetVoucherActivityByActivity(activityId));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<VoucherActivityVM> Add([FromBody] VoucherActivityVM voucherActivityVM)
        {
            return await _voucher.Add(voucherActivityVM);
        }

    }
}
