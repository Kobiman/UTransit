using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTransit.Models.Requests
{
    public class GetStudentRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
