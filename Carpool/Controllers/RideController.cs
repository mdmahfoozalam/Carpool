using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Carpool.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Carpool.Models.Ride;
using Carpool.Services;
using Microsoft.AspNetCore.Authorization;
using Carpool.Models.Common;

namespace Carpool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RideController 
    {
        private readonly IRideService _offerService;

        public RideController(IRideService offerService)
        {
            _offerService = offerService;
        }


        [HttpGet("getAllOfferedRide")]
        public ApiResponse<List<RideDetails>> GetAllRides()
        {
            return _offerService.GetAllRides();
        }

        [HttpGet("getOfferedRide")]
        public ApiResponse<List<RideResponse>> GetRides(int userId)
        {
            return _offerService.GetRides(userId);
        }

        //[HttpPut("updateRide")]
        //public string UpdateRide(RideDetails rideDetails)
        //{
        //    return _offerService.UpdateRide(rideDetails);
        //}


        [HttpPost("addRide")]
        public object AddRide(RideDetails rideDetails)
        {
            return _offerService.AddRide(rideDetails);
        }


        [HttpPost("getAvailableRides")]
        public ApiResponse<List<RideResponse>> GetAvailabeRides(RideRequest rideRequest, int pricePerKm)
        {
            return _offerService.GetAvailableRides(rideRequest, pricePerKm);
        }

        [HttpGet("getAllLocations")]
        public ApiResponse<List<Locations>> GetAllLocations()
        {
            return _offerService.GetLocations();
        }


    }
}
