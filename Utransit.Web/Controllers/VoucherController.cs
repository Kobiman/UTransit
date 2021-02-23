using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utransit.Services.Contracts;
using UTransit.Models;

namespace Utransit.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly ITripVoucherService _voucherService;
        public VoucherController(ITripVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [HttpPost,Route("UploadVouchers")]
        public IActionResult UploadVoucher([FromBody] IList<TripVoucher> vouchers)
        {
            var result = _voucherService.UploadVoucher(vouchers);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet, Route("UpdateVoucher/{voucherId}")]
        public IActionResult UpdateVoucher([FromRoute]string voucherId)
        {
            var result = _voucherService.UpdateVoucher(voucherId);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }
    }
}
