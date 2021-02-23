using System;
using System.Collections.Generic;
using System.Text;
using UTransit.Models;

namespace UTransit.Data.Models
{
    public class Vouchers
    {
        public Voucher[] Next { get; set; }
        public int Heigth { get; set; }
        private int _limit;
        private int index;
        public Vouchers(int limit)
        {
            Next = new Voucher[limit];
            _limit = limit;
            index = 0;
            Heigth = 0;
        }

        public void Add(TripVoucher voucher)
        {
            lock (voucher)
            {
                if (Heigth > _limit - 1)
                {
                    if (index == _limit) { index = 0; }
                    Next[index].Add(voucher);
                    index++;
                }
                else
                {
                    Next[Heigth] = new Voucher(1000);
                    Next[index].Add(voucher);
                    Heigth++;
                }
            }
        }
    }

    public class Voucher
    {
        public Voucher(int length)
        {
            VoucherId = new string[length];
            Amount = new float[length];
            Used = new bool[length];
            UsedBy = new string[length];
            UsedOn = new DateTime?[length];
            CreatedOn = new DateTime[length];
            State = new int[length];
            Count = 0;
        }

        public int Count;
        public string[] VoucherId;
        public float[] Amount;
        public bool[] Used;
        public string[] UsedBy;
        public DateTime?[] UsedOn;
        public DateTime[] CreatedOn;
        public int[] State;

        public void Add(TripVoucher voucher)
        {
            lock (voucher)
            {
                if (Count == VoucherId.Length)
                {
                    var newLength = VoucherId.Length + 1000;
                    var _voucherId = new string[newLength];
                    VoucherId.CopyTo(_voucherId, 0);
                    VoucherId = _voucherId;

                    var _amount = new float[newLength];
                    Amount.CopyTo(_amount, 0);
                    Amount = _amount;

                    var _used = new bool[newLength];
                    Used.CopyTo(_used, 0);
                    Used = _used;

                    var _usedBy = new string[newLength];
                    UsedBy.CopyTo(_usedBy, 0);
                    UsedBy = _usedBy;

                    var _usedOn = new DateTime?[newLength];
                    UsedOn.CopyTo(_usedOn, 0);
                    UsedOn = _usedOn;

                    var _createdOn = new DateTime[newLength];
                    CreatedOn.CopyTo(_createdOn, 0);
                    CreatedOn = _createdOn;

                    var _state = new int[newLength];
                    State.CopyTo(_state, 0);
                    State = _state;
                }
                VoucherId[Count] = voucher.VoucherId;
                Amount[Count] = voucher.Amount;
                Used[Count] = voucher.Used;
                UsedBy[Count] = voucher.UsedBy;
                UsedOn[Count] = voucher.UsedOn;
                State[Count] ++;

                Count++;
            }
        }
    }
}
