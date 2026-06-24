using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Booking
    {
        internal int availableSeats;

        public int bookingId { get; set; } // System generate 
        public int flightId { get; set; }
        public int passengerId { get; set; }
        public string seatNumber { get; set; }
        public string bookingDate { get; set; }
        public decimal totalPrice { get; set; }
        public string status { get; set; } //Confirmed | Cancelled
    }
}
