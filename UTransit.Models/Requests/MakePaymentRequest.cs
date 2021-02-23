using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTransit.Models.Requests
{
    public class MakePaymentRequest
    {
        public string IndexNumber { get; set; }
        public string BusNumber { get; set; }
        public float Amount { get; set; }
    }
}
