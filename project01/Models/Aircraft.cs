using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Aircraft
    {
        public int aircraftId { get; set; } // System generate
        public string model { get; set; }
        public int totalSeats { get; set; }
        public bool isOperational { get; set; } = false; //default value = false
    }
}
