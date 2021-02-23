using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTransit.Models;
using UTransit.Models.Requests;

namespace Utransit.Services.Contracts
{
    public interface IUserService
    {
        IResult Login(LoginRequest request);
        IResult AddUsers(IList<User> users);
    }
}
