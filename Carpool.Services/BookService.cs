using AutoMapper;
using Carpool.Data.Models;
using Carpool.Models.Book;
using Carpool.Models.Ride;
using Carpool.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services
{
    public class BookService : IBookService
    {
        private readonly CarpoolContext _context;
        private readonly IMapper _mapper;
        public BookService(CarpoolContext context,IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<BookingDetails> BookedRide(int userId)
        {
            var response = _context.Booking.Where(f => f.UserId == userId).ToList();
            return _mapper.Map<List<BookingDetails>>(response);
        }

        public string BookRide(int rideId, int userId )
        {
            try
            {
                var user = _context.Ride.Where(f => f.RideId == rideId).FirstOrDefault();
                if(user != null)
                {
                    var vehicle = _context.Vehicle.Where(u => u.UserId == user.UserId).FirstOrDefault();
                    if (vehicle != null)
                    {
                        if (vehicle.Seats > 0)
                        {
                            vehicle.Seats--;

                        }
                        if (vehicle.Seats == 0)
                        {
                            user.IsBooked = true;
                        }
                    }

                    _context.Booking.Add(new Booking()
                    {
                        UserId = userId,
                        RideId = user.RideId,
                        SourceId = user.SourceId,
                        DestinationId = user.DestinationId,
                        Date = user.Date,
                        Time = user.Time

                    });
                    _context.SaveChanges();
                    return "Ride booked";
                }
                
                else
                {
                    return "No ride available";
                }   
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }


    }
}
