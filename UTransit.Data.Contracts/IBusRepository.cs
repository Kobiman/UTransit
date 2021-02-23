using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTransit.Models;

namespace UTransit.Data.Contracts
{
    public interface IBusRepository
    {
        Bus GetByRegistrationNumber(string indexNumber);
    }
}
