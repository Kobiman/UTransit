using System;
using System.Collections.Generic;
using System.Text;

namespace UTransit.Models
{
    public class TripVoucher
    {
        public TripVoucher()
        {
            VoucherId = Guid.NewGuid().ToString();
            CreatedOn = DateTime.Now;
        }
        public string VoucherId { get; set; }
        public float Amount { get; set; }
        public bool Used { get; set; }
        public string UsedBy { get; set; }
        public DateTime? UsedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public int State { get; set; }
    }
}
