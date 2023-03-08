using Carpool.Models.Ride;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interfaces
{
    public interface IRideService
    {
        public IEnumerable<RideDetails> GetAllRides();

        public IEnumerable<Locations> GetLocations();
        public IEnumerable<RideResponse> GetRides(int userId);
       // public string UpdateRide(RideDetails rideDetails);

        //public string UpdateOfferPartial(int offerId, JsonPatchDocument updateOfferModel);

        public IEnumerable<RideResponse> GetAvailableRides(RideRequest rideRequestModel, int pricePerKm);

        public object AddRide(RideDetails rideDetails);
    }
}
