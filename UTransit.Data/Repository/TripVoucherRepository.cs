using System;
using System.Collections.Generic;
using System.Text;
using UTransit.Data.Contracts;
using UTransit.Data.Models;
using UTransit.Models;

namespace UTransit.Data.Repository
{
    public class TripVoucherRepository : ITripVoucherRepository
    {
        private Vouchers _vouchers;
        public TripVoucherRepository(Vouchers vouchers)
        {
            _vouchers = vouchers;
        }
        public bool UpdateVoucher(string voucherId)
        {
            var result = _vouchers.Next.Find((x, y) => x.VoucherId[y] == voucherId);
            if (!result.success) return false;
            result.Value.Used[result.Index] = true;
            result.Value.State[result.Index]++;
            var voucher = CreateVoucher(result);
            DataWriter.Add(voucher, "Vouchers");
            return true;
        }

        public TripVoucher GetById(string voucherId)
        {
            var result = _vouchers.Next.Find((x, y) => x.VoucherId[y] == voucherId);
            return CreateVoucher(result);
        }

        public bool UploadVoucher(IList<TripVoucher> tripVoucher)
        {
            foreach(var t in tripVoucher)
            {
                _vouchers.Add(t);
                DataWriter.Add(t, "Vouchers");
            }
            return true;
        }

        public bool UploadVoucher(TripVoucher tripVoucher)
        {
            _vouchers.Add(tripVoucher);
            DataWriter.Add(tripVoucher,"Vouchers");
            return true;
        }

        private static TripVoucher CreateVoucher((Voucher Value, int Index, bool Success) result)
        {
            if(!result.Success) return null;
            return new TripVoucher
            {
                Amount = result.Value.Amount[result.Index],
                VoucherId = result.Value.VoucherId[result.Index],
                Used = result.Value.Used[result.Index],
                UsedBy = result.Value.UsedBy[result.Index],
                UsedOn = result.Value.UsedOn[result.Index],
                CreatedOn = result.Value.CreatedOn[result.Index],
                State = result.Value.State[result.Index],
            };
        }
    }
}
