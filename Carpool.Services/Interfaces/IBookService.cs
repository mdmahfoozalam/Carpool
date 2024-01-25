using Carpool.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Carpool.Models.Ride;
using Carpool.Models.Book;
using Carpool.Models.Common;

namespace Carpool.Services.Interfaces
{
    public interface IBookService
    {
        

        public ApiResponse<string> BookRide(int rideId, int userId);

        public ApiResponse<List<Bookings>> GetBookedRide(int userId);
    }
}
