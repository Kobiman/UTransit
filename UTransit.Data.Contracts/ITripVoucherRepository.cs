using System;
using System.Collections.Generic;
using UTransit.Models;

namespace UTransit.Data.Contracts
{
    public interface ITripVoucherRepository
    {
        bool UploadVoucher(IList<TripVoucher> tripVoucher);
        bool UploadVoucher(TripVoucher tripVoucher);
        bool UpdateVoucher(string voucherId);
        TripVoucher GetById(string voucherId);
    }
}
