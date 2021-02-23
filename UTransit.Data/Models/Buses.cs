using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTransit.Data.Models
{
    public class Buses
    {
        public Bus[] Next { get; set; }
        public int Heigth { get; set; }
        private int _limit;
        private int index;
        public Buses(int limit)
        {
            Next = new Bus[limit];
            _limit = limit;
            index = 0;
            Heigth = 0;
        }

        public void Add(UTransit.Models.Bus bus)
        {
            lock (bus)
            {
                if (Heigth > _limit - 1)
                {
                    if (index == _limit) { index = 0; }
                    Next[index].Add(bus);
                    index++;
                }
                else
                {
                    Next[Heigth] = new Bus(1000);
                    Next[index].Add(bus);
                    Heigth++;
                }
            }
        }
    }

    public class Bus
    {
        public Bus(int length)
        {
            RegistrantionNo = new string[length];
            Type = new string[length];
            Color = new string[length];
        }

        public int Count;
        public string[] RegistrantionNo;
        public string[] Type;
        public string[] Color;

        public void Add(UTransit.Models.Bus bus)
        {
            lock (bus)
            {
                if (Count == RegistrantionNo.Length)
                {
                    var newLength = RegistrantionNo.Length + 1000;
                    var registrantionNo = new string[newLength];
                    RegistrantionNo.CopyTo(registrantionNo, 0);
                    RegistrantionNo = registrantionNo;

                    var type = new string[newLength];
                    Type.CopyTo(type, 0);
                    Type = type;

                    var color = new string[newLength];
                    Color.CopyTo(color, 0);
                    Color = color;
                }

                RegistrantionNo[Count] = bus.RegistrantionNo;
                Type[Count] = bus.Type;
                Color[Count] = bus.Color;
                Count++;
            }
        }
    }
}
