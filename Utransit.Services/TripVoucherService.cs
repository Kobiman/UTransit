using System;
using System.Collections.Generic;
using Utransit.Services.Contracts;
using UTransit.Data.Contracts;
using UTransit.Models;

namespace Utransit.Services
{   
    public class TripVoucherService : ITripVoucherService
    {
        private readonly IDataSource _dataSource;
        public TripVoucherService(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IResult UploadVoucher(IList<TripVoucher> tripVoucher)
        {
            if (tripVoucher.Count == 0) return new Result(false, "Operation Failed.");
            _dataSource.Vouchers.UploadVoucher(tripVoucher);
            return new Result(true, "Operation Successful.");
        }

        public IResult UploadVoucher(TripVoucher tripVoucher)
        {
            if (tripVoucher is null) return new Result(false, "Operation Failed.");
            _dataSource.Vouchers.UploadVoucher(tripVoucher);
            return new Result(true, "Operation Successful.");
        }

        public IResult UpdateVoucher(string voucherId)
        {
            if (string.IsNullOrWhiteSpace(voucherId)) return new Result(false, "VoucherId cannot be null.");
            _dataSource.Vouchers.UpdateVoucher(voucherId);
            return new Result(true, "Operation Successful.");
        }
    }
}
