using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpoolmodels
{
    public class Ride
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime Ride_Date { get; set; }
        public DateTime Ride_Time { get; set; }
        public int Empid { get; set; }
    }
}
