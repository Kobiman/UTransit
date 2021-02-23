using System;
using System.Collections.Generic;
using System.Text;

namespace UTransit.Models
{
    public class BusLocation
    {
        public string LocationId { get; set; }
        public string BusId { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Passengers { get; set; }
        public DateTime Date { get; set; }
    }
}
