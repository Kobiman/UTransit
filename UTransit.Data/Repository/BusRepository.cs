using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTransit.Data.Contracts;
using UTransit.Data.Models;
using UTransit.Models;

namespace UTransit.Data.Repository
{
    public class BusRepository : IBusRepository
    {
        private Buses _buses;
        public BusRepository(Buses buses)
        {
            _buses = buses;
        }
        public UTransit.Models.Bus GetByRegistrationNumber(string registrationNumber)
        {
            var result = _buses.Next.Find((x, y) => x.RegistrantionNo[y] == registrationNumber);
            if (!result.success) return null;
            return new UTransit.Models.Bus
            {
                RegistrantionNo = result.Value.RegistrantionNo[result.Index],
                Color = result.Value.Color[result.Index],
                Type = result.Value.Type[result.Index],
            };
        }
    }
}
