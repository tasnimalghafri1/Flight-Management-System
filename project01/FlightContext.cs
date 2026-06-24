using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project01.Models;

namespace project01
{
    public class FlightContext
    {
       public List<Flight> Flights { get; set; }
        public List<Pilot> Pilots { get; set; }
        public List<Aircraft> Aircrafts { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Passenger> Passengers { get; set; }
    }
}
