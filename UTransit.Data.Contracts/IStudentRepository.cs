using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTransit.Models;
using UTransit.Models.Requests;

namespace UTransit.Data.Contracts
{
    public interface IStudentRepository
    {
        Student GetByIndexNumber(string indexNumber);
        bool AddStudent(Student student);
        bool AddStudents(IList<Student> students);
        (bool Success, float Balance) MakePayment(StudentTransaction transaction);
        (bool Success, float Balance) BuyVoucher(StudentTransaction transaction);
    }
}
