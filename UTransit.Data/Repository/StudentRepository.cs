using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTransit.Data.Contracts;
using UTransit.Data.Models;
using UTransit.Models.Requests;

namespace UTransit.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Students _students;
        public StudentRepository(Students students)
        {
            _students = students;
        }

        public bool AddStudent(UTransit.Models.Student student)
        {
           _students.Add(student);
           DataWriter.Add(student, "Students");
           return true;
        }

        public bool AddStudents(IList<UTransit.Models.Student> students)
        {
            foreach(var s in students)
            {
                _students.Add(s);
                DataWriter.Add(s, "Students");
            }
            
            return true;
        }

        public (bool Success, float Balance) MakePayment(UTransit.Models.StudentTransaction transaction)
        {
            var result = _students.Next.Find((x, y) => x.IndexNumber[y] == transaction.IndexNumber);
            if (result.success && result.Value.Balance[result.Index] >= Math.Abs(transaction.Amount))
            {
                result.Value.Transactions[result.Index].Add(transaction);
                result.Value.Balance[result.Index] += transaction.Amount;
                DataWriter.Add(transaction, "Transactions");
                return (Success: true, result.Value.Balance[result.Index]);
            }
            return (Success: false, result.Value.Balance[result.Index]);
        }

        public (bool Success,float Balance) BuyVoucher(UTransit.Models.StudentTransaction transaction)
        {
            var result = _students.Next.Find((x, y) => x.IndexNumber[y] == transaction.IndexNumber);
            if (result.success)
            {
                result.Value.Transactions[result.Index].Add(transaction);
                result.Value.Balance[result.Index] += transaction.Amount;
                DataWriter.Add(transaction, "Transactions");
                return (Success: true, result.Value.Balance[result.Index]);
            }
            return (Success: false, result.Value.Balance[result.Index]);
        }

        public UTransit.Models.Student GetByIndexNumber(string indexNumber)
        {
            var result = _students.Next.Find((x, y) => x.IndexNumber[y] == indexNumber);
            return CreateStudent(result);
        }


        private static UTransit.Models.Student CreateStudent((Student Value, int Index, bool Success) result)
        {
            if (!result.Success) return null;
            return new UTransit.Models.Student
            {
                IndexNumber = result.Value.IndexNumber[result.Index],
                Name = result.Value.Name[result.Index],
                Balance = result.Value.Balance[result.Index],
                Transactions = result.Value.Transactions[result.Index].Select((a, b) =>
                {
                    return new UTransit.Models.StudentTransaction
                    {
                        Amount = a.Amount[b],
                        Date = a.Date[b],
                        IndexNumber = a.IndexNumber[b],
                        TransactionId = a.TransactionId[b],
                        BusNumber = a.BusNumber[b]
                    };
                }).ToList(),
                State = result.Value.State[result.Index]
            };
        }
    }
}
