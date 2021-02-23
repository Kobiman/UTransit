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
    public class UserService : IUserService
    {
        private readonly IDataSource _dataSource;
        public UserService(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IResult Login(LoginRequest request)
        {
            var user = _dataSource.Users.Login(request);
            if (user.Success && user.Type == "Student")
            {
                var student = _dataSource.Students.GetByIndexNumber(user.IndexNumber);
                if (student is null) return new Result(false, "Invalid index number.");
                return new Result<Student>(true, student, "Operation successful.");
            }
            if (user.Success && user.Type == "Bus")
            {
                var bus = _dataSource.Buses.GetByRegistrationNumber(user.IndexNumber);
                if (bus is null) return new Result(false, "Invalid registration number.");
                return new Result<Bus>(true, bus, "Operation successful.");
            }
            return new Result(false, "Operation failed.");
        }

        public IResult AddUsers(IList<User> users)
        {
            var reslut = _dataSource.Users.AddUsers(users);
            return new Result(reslut, "Operation successful.");
        }
    }
}
