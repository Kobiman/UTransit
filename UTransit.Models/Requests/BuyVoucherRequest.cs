using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTransit.Models.Requests
{
    public class BuyVoucherRequest
    {
        public string VoucherId { get; set; }
        public string IndexNumber { get; set; }
    }
}
