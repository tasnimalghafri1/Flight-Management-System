using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Pilot
    {
        public int pilotId { get; set; }// System generate
        public string pilotName { get; set; }// user input 
        public string pilotPhone { get; set; }// user input
        public string licenseNumber { get; set; }// user input      
        public int flightHours { get; set; }
        public bool isAvailable { get; set; } = false; //default value = false
    }
}
