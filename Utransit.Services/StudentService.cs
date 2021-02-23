using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utransit.Services.Contracts;
using UTransit.Data.Contracts;
using UTransit.Models;
using UTransit.Models.Requests;

namespace Utransit.Services
{
    public class StudentService : IStudentService
    {
        private readonly IDataSource _dataSource;
        public StudentService(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        public IResult AddStudents(IList<Student> students)
        {
            _dataSource.Students.AddStudents(students);
            return new Result(true, "Operation completed successfully.");
        }

        public IResult AddStudent(Student student)
        {
            _dataSource.Students.AddStudent(student);
            return new Result(true, "Operation completed successfully.");
        }

        public IResult GetStudent(string indexNumber)
        {
            var student = _dataSource.Students.GetByIndexNumber(indexNumber);
            if(student == null) return new Result(false, "Operation failed.");
            return new Result<Student>(true, student, "Operation completed successfully.");
        }

        //public IResult GetStudent(GetStudentRequest request)
        //{
        //    var student = _dataSource.Students.GetStudent(request);
        //    return new Result<Student>(true, student, "Operation completed successfully.");
        //}

        public IResult BuyVoucher(BuyVoucherRequest request)
        {
            var voucher = _dataSource.Vouchers.GetById(request.VoucherId);
            if(voucher == null) { return new Result(false, "Voucher does not exist."); }
            if (voucher.Used is true) return new Result(false, "Voucher has been used.");
            var student = _dataSource.Students.GetByIndexNumber(request.IndexNumber);
            if (student is null) return new Result(false,"Invalid index number.");
            var transaction = new StudentTransaction { Amount = voucher.Amount, IndexNumber = student.IndexNumber };
            var result =_dataSource.Students.BuyVoucher(transaction);
            _dataSource.Vouchers.UpdateVoucher(request.VoucherId);
            //_dataSource.Transactions.Add(transaction);
            return new Result<float>(true, result.Balance, "Operation completed successfully.");
        }

        public IResult MakePayment(MakePaymentRequest request)
        {
            var student = _dataSource.Students.GetByIndexNumber(request.IndexNumber);
            if(student is null) return new Result(false, "Invalid index number.");
            var transaction = new StudentTransaction
            {
                Amount = -Math.Abs(request.Amount),
                IndexNumber = request.IndexNumber
            };

            var result = _dataSource.Students.MakePayment(transaction);
            if (result.Success)
            {
                return new Result<float>(true, result.Balance, "Operation completed successfully.");
            }
            return new Result<float>(false, result.Balance, "Operation failed.");
        }
    }
}
