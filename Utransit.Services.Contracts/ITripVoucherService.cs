using System;
using System.Collections.Generic;
using UTransit.Models;

namespace Utransit.Services.Contracts
{
    public interface ITripVoucherService
    {
        IResult UpdateVoucher(string voucherId);
        IResult UploadVoucher(TripVoucher tripVoucher);
        IResult UploadVoucher(IList<TripVoucher> tripVoucher);
    }
}
