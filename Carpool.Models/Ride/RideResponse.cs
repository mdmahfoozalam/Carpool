using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Models.Ride
{
    public class RideResponse:RideRequest
    {
        public string Name { get; set; }

        public int RideId { get; set; }

        public int Price { get; set; }

        public int SeatAvailable { get; set; }
        
    }
}
