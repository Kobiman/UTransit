using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTransit.Data.Models
{
    public class StudentTransactions
    {
        public StudentTransaction[] Next { get; set; }
        public int Heigth { get; set; }
        private int _limit;
        private int index;
        public StudentTransactions(int limit)
        {
            Next = new StudentTransaction[limit];
            _limit = limit;
            index = 0;
            Heigth = 0;
        }

        public void Add(UTransit.Models.StudentTransaction transaction)
        {
            lock (transaction)
            {
                if (Heigth > _limit - 1)
                {
                    if (index == _limit) { index = 0; }
                    Next[index].Add(transaction);
                    index++;
                }
                else
                {
                    Next[Heigth] = new StudentTransaction(1000);
                    Next[index].Add(transaction);
                    Heigth++;
                }
            }
        }
    }

    public class StudentTransaction
    {
        public StudentTransaction(int length)
        {
            TransactionId = new string[length];
            Amount = new float[length];
            IndexNumber = new string[length];
            BusNumber = new string[length];
            State = new int[length];
            Date = new DateTime[length];
            Count = 0;
        }

        public int Count;
        public string[] TransactionId;
        public float[] Amount;
        public string[] IndexNumber;
        public string[] BusNumber;
        public int[] State;
        public DateTime[] Date;

        public void Add(UTransit.Models.StudentTransaction transaction)
        {
            lock (transaction)
            {
                if(Count == TransactionId.Length)
                {
                    var newLength = TransactionId.Length + 1000;
                    var _transactionId = new string[newLength];
                    TransactionId.CopyTo(_transactionId, 0);
                    TransactionId = _transactionId;

                    var _amount = new float[newLength];
                    Amount.CopyTo(_amount, 0);
                    Amount = _amount;

                    var _indexNumber = new string[newLength];
                    IndexNumber.CopyTo(_indexNumber, 0);
                    IndexNumber = _indexNumber;

                    var _busNumber = new string[newLength];
                    BusNumber.CopyTo(_busNumber, 0);
                    BusNumber = _indexNumber;

                    var _state = new int[newLength];
                    State.CopyTo(_state, 0);
                    State = _state;

                    var _date = new DateTime[newLength];
                    Date.CopyTo(_date, 0);
                    Date = _date;
                }

                TransactionId[Count] = transaction.TransactionId;
                Amount[Count] = transaction.Amount;
                IndexNumber[Count] = transaction.IndexNumber;
                BusNumber[Count] = transaction.BusNumber;
                State[Count]++;
                Count++;
            }
        }
    }
}
