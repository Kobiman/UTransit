using System;

namespace UTransit.Models
{
    public class Trip
    {
        public Trip()
        {
            TripId = Guid.NewGuid().ToString();
        }
        public string TripId { get; set; }
        public DateTime Date { get; set; }
        public string ReferenceNumber { get; set; }
        public string BusRegistrantionNo { get; set; }
        public DateTime StartTime { get; set; }//
        public DateTime EndTime { get; set; }//
        public float FareAmount { get; set; }
        public string Origion { get; set; }//
        public string OrigionCordinate { get; set; }//
        public string Destination { get; set; }//
        public string DestinationCordinate { get; set; }//
    }
}
