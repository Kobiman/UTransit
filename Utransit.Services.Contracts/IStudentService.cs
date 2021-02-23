using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTransit.Models;
using UTransit.Models.Requests;

namespace Utransit.Services.Contracts
{
    public interface IStudentService
    {
        IResult AddStudents(IList<Student> students);
        IResult AddStudent(Student student);
        IResult GetStudent(string indexNumber);
        //IResult GetStudent(GetStudentRequest request);
        IResult BuyVoucher(BuyVoucherRequest request);
        IResult MakePayment(MakePaymentRequest request);
    }
}
