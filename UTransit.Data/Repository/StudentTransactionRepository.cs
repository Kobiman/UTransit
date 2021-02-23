using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTransit.Data.Contracts;
using UTransit.Models;

namespace UTransit.Data.Repository
{
    public class StudentTransactionRepository : IStudentTransactionRepository
    {
        public StudentTransactionRepository()
        {

        }
        public bool Add(StudentTransaction transaction)
        {
            DataWriter.Add(transaction,"Transactions");
            return true;
        }
    }
}
