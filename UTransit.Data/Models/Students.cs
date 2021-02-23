using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTransit.Data.Models
{
    public class Students
    {
        public Student[] Next { get; set; }
        public int Heigth { get; set; }
        private int _limit;
        private int index;
        public Students(int limit)
        {
            Next = new Student[limit];
            _limit = limit;
            index = 0;
            Heigth = 0;
        }

        public void Add(UTransit.Models.Student student)
        {
            lock (student)
            {
                if (Heigth > _limit - 1)
                {
                    if (index == _limit) { index = 0; }
                    Next[index].Add(student);
                    index++;
                }
                else
                {
                    Next[Heigth] = new Student(1000);
                    Next[index].Add(student);
                    Heigth++;
                }
            }
        }
    }

    public class Student
    {
        public Student(int length)
        {
            this.length = length;
            IndexNumber = new string[length];           
            Name = new string[length];            
            Balance = new float[length];
            State = new int[length];
            Transactions = new StudentTransaction[length];
            Count = 0;
        }

        public int Count;
        public string[] IndexNumber;        
        public string[] Name;
        public float[] Balance;
        //public IList<Trip> Trips { get; set; }
        public StudentTransaction[] Transactions;
        public int[] State;
        private readonly int length;


        public void Add(UTransit.Models.Student student)
        {
            lock (student)
            {
                if (Count == IndexNumber.Length)
                {
                    var newLength = IndexNumber.Length + 1000;
                    var indexNumber = new string[newLength];
                    IndexNumber.CopyTo(indexNumber, 0);
                    IndexNumber = indexNumber;

                    var name = new string[newLength];
                    Name.CopyTo(name, 0);
                    Name = name;

                    var balance = new float[newLength];
                    Balance.CopyTo(balance, 0);
                    Balance = balance;

                    var _transactions = new StudentTransaction[newLength];
                    Transactions.CopyTo(_transactions, 0);
                    Transactions = _transactions;

                    var _state = new int[newLength];
                    State.CopyTo(_state, 0);
                    State = _state;
                }
            }
            IndexNumber[Count] = student.IndexNumber;
            Name[Count] = student.Name;
            Balance[Count] = student.Balance;
            Transactions[Count] = new StudentTransaction(length);
            if(student.Transactions.Count > 0){
                foreach(var t in student.Transactions)
                {
                    Transactions[Count].Add(t);
                }
            }
            State[Count]++;

            Count++;
        }
    }
}
