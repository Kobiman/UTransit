using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTransit.Models;
using UTransit.Models.Requests;

namespace UTransit.Data.Contracts
{
    public interface IUserRepository
    {
        (bool Success, string IndexNumber, string Type) Login(LoginRequest request);
        bool AddUsers(IList<User> users);
    }
}
