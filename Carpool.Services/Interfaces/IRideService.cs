using Carpool.Models.Common;
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
        public ApiResponse<List<RideDetails>> GetAllRides();

        public ApiResponse<List<Locations>> GetLocations();
        public ApiResponse<List<RideResponse>> GetRides(int userId);
       
        //public string UpdateOfferPartial(int offerId, JsonPatchDocument updateOfferModel);

        public ApiResponse<List<RideResponse>> GetAvailableRides(RideRequest rideRequestModel, int pricePerKm);

        public object AddRide(RideDetails rideDetails);
    }
}
