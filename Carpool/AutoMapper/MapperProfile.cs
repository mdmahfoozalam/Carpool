using AutoMapper;
using Carpool.Data.Models;
using Carpool.Models.Book;
using Carpool.Models.Ride;
using Carpool.Models.User;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Carpool.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Location, Locations>();
            CreateMap<Ride,RideDetails>();
            CreateMap<User, UserViewModel>();
            //CreateMap<Booking, BookingDetails>();
        }
        
    }
}
