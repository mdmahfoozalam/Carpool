﻿using AutoMapper;
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

        public IEnumerable<Bookings> GetBookedRide(int userId)
        {
            var response = _context.Bookings.Where(f => f.UserId == userId).ToList();
            return response;
        }   

        public string BookRide(int rideId, int userId )
        {
            try
            {
                var ride = _context.Ride.FirstOrDefault(f => f.RideId == rideId);
                if(ride != null)
                {
                    var vehicle = _context.Vehicle.Where(u => u.UserId == ride.UserId).FirstOrDefault();
                    if (vehicle != null)
                    {
                        if (vehicle.Seats > 0)
                        {
                            vehicle.Seats--;

                        }
                        if (vehicle.Seats == 0)
                        {
                            ride.IsBooked = true;
                        }
                    }

                    //_context.Booking.Add(new Booking()
                    //{
                    //    UserId = userId,
                    //    RideId = user.RideId,
                    //    SourceId = user.SourceId,
                    //    DestinationId = user.DestinationId,
                    //    Date = user.Date,
                    //    Time = user.Time

                    //});
                    _context.Bookings.Add(new Bookings()
                    {
                        UserId = userId,
                        RideId = ride.RideId,
                        Source = _context.Location.FirstOrDefault(x => x.Id == ride.SourceId)?.Name,
                        Destination = _context.Location.FirstOrDefault(x => x.Id == ride.DestinationId)?.Name,
                        Date= ride.Date,
                        Time = ride.Time,
                        Price = ride.Distance,
                        Seats =vehicle.Seats
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
