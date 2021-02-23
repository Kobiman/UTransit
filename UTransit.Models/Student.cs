using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UTransit.Models.Requests;

namespace UTransit.Models
{
    public class Student 
    {
        public Student()
        {
            Transactions = new List<StudentTransaction>();
        }
        public string IndexNumber { get; set; }
        public string Name { get; set; }        
        public float Balance { get; set; }
        public int State { get; set; }
        //public IList<Trip> Trips { get; set; }
        public IList<StudentTransaction> Transactions { get; set; }

        //public void BuyVoucher(StudentTransaction transaction)
        //{
        //    Transactions.Add(transaction);
        //    Balance = Transactions.Select(x => x.Amount).Sum();
        //}

        //public bool MakePayment(StudentTransaction transaction)
        //{
        //    if(transaction.Amount <= Balance)
        //    {
        //        Transactions.Add(transaction);
        //        Balance = Transactions.Select(x => x.Amount).Sum();
        //        return true;
        //    }
        //    return false;
        //}
    }
}
