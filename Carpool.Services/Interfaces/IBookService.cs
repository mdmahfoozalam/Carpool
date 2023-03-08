using Carpool.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Carpool.Models.Ride;
using Carpool.Models.Book;

namespace Carpool.Services.Interfaces
{
    public interface IBookService
    {
        

        public string BookRide(int rideId, int userId);

        public IEnumerable<Bookings> GetBookedRide(int userId);
    }
}
