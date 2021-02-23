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
    public class UserRepository : IUserRepository
    {
        private Users _users;
        public UserRepository(Users users)
        {
            _users = users;
        }

        public bool AddUsers(IList<UTransit.Models.User> users)
        {
            foreach(var user in users)
            {
                _users.Add(user);
                DataWriter.Add(user,"Users");
            }
            return true;
        }

        public (bool Success, string IndexNumber, string Type) Login(LoginRequest request)
        {
           var result = _users.Next.Find((x,y)=> x.Username[y] == request.Username && x.Password[y] == request.Password);
            if (result.success) return (true, result.Value.IndexNumber[result.Index], result.Value.Type[result.Index]);
            return (false, "Not found", "Not found.");
        }
    }
}
