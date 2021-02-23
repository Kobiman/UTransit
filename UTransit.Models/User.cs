using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTransit.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string IndexNumber { get; set; }
        public int State { get; set; }
        //public string IndexNumber { get; set; }
    }
}
