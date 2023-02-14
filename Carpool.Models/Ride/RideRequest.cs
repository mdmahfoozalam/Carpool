using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Models.Ride
{
    public class RideRequest
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
    }
}
