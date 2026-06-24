using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Flight
    {
        public int flightId { get; set; } // System generate
        public string flightCode { get; set; }
        public int aircraftId { get; set; }
        public int pilotId { get; set; }

        public string origin { get; set; }

        public string destination { get; set; }
        public string departureTime { get; set; }
        public string departureDate { get; set; }
        public decimal ticketPrice { get; set; }
        public string flightDuration { get; set; }
        public int availableSeats { get; set; }
        public string status { get; set; } //Scheduled | Departed | Cancelled
    }
}
