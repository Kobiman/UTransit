using System;
using System.Collections.Generic;
using System.Text;

namespace UTransit.Models
{
    public class StudentTransaction
    {
        public StudentTransaction()
        {
            TransactionId = Guid.NewGuid().ToString();
            Date = DateTime.Now;
        }
        public DateTime Date { get; set; }
        public string TransactionId { get; set; }
        public float Amount { get; set; }
        public string IndexNumber { get; set; }
        public string BusNumber { get; set; }
        //Add DeviceName OS
        public int State { get; set; }
    }
}
