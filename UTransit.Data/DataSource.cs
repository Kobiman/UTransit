using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTransit.Data.Contracts;
using UTransit.Data.Models;
using UTransit.Data.Repository;

namespace UTransit.Data
{
    public class DataSource : IDataSource
    {
        public DataSource()
        {
            DataWriter.Start(10);
        }

        private static ITripVoucherRepository vouchers;
        public ITripVoucherRepository Vouchers => vouchers ??= new TripVoucherRepository(ReadVouchers());

        private static IStudentRepository students;
        public IStudentRepository Students => students ??= new StudentRepository(ReadStudents());

        private IUserRepository uses;
        public IUserRepository Users => uses ??= new UserRepository(ReadUsers());

        private IBusRepository buses;
        public IBusRepository Buses => buses ??= new BusRepository(ReadBuses());

        //public static IStudentTransactionRepository transactions;
        //public IStudentTransactionRepository Transactions => transactions ??= new StudentTransactionRepository();

        private static Buses ReadBuses()
        {
            var buses = DataReader.ReadBuses("Buses")
                        .Distinct(x => x.RegistrantionNo, x => x.State);
            var voucher = new Buses(3000);
            foreach (var u in buses)
            {
                voucher.Add(u);
            }
            return voucher;
        }

        private static Users ReadUsers()
        {
            var users = DataReader.ReadUsers("Users")
                        .Distinct(x => x.IndexNumber, x => x.State);
            var voucher = new Users(3000);
            foreach (var u in users)
            {
                voucher.Add(u);
            }
            return voucher;
        }

        private Students ReadStudents()
        {
            var _students = DataReader.ReadStudents("Students")
                        .Distinct(x => x.IndexNumber, x => x.State).ToList();
            var students = new Students(3000);

            var transactions = DataReader.ReadTransactions("Transactions")
                        .Distinct(x => x.TransactionId, x => x.State).ToList();

            foreach (var u in _students)
            {
                u.Transactions = transactions.Where(x=>x.IndexNumber == u.IndexNumber).ToList();
                u.Balance = transactions.Select(x => x.Amount).Sum();
                students.Add(u);
            }
            return students;
        }

        private static Vouchers ReadVouchers()
        {
            var vouchers = DataReader.ReadVouchers("Vouchers")
                        .Distinct(x => x.VoucherId, x => x.State);
            var voucher = new Vouchers(3000);
            foreach(var u in vouchers)
            {
                voucher.Add(u);
            }
            return voucher;
        }
    }
}
