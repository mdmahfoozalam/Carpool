using AutoMapper;
using Carpool.Data.Models;
using Carpool.Models.Book;
using Carpool.Models.Ride;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Carpool.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Ride,RideDetails>();
            CreateMap<Booking, BookingDetails>();
        }
        
    }
}
