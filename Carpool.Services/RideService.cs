using AutoMapper;
using Carpool.Data.Models;
using Carpool.Models.Common;
using Carpool.Models.Ride;
using Carpool.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services
{
    public class RideService : IRideService
    {
        private readonly CarpoolContext _context;
        private readonly IMapper _mapper;

        public RideService(CarpoolContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        public ApiResponse<List<RideDetails>> GetAllRides()
        {
            try
            {
                var res = new List<RideDetails>();
                var result = new ApiResponse<List<RideDetails>>();
                //return _mapper.Map<IEnumerable<RideDetails>>(_context.Ride);
                var allRides = _context.Ride.ToList();
                foreach (var r in allRides)
                {
                    res.Add(new RideDetails()
                    {
                        RideId = r.RideId,
                        UserId = r.UserId,
                        Source = _context.Location.FirstOrDefault(x => x.Id == r.SourceId).Name,
                        Destination = _context.Location.FirstOrDefault(x => x.Id == r.DestinationId).Name,
                        Date = r.Date,
                        Time = r.Time

                    });
                }
                result.Data = res;
                result.IsSuccess = true;
                return result;
            }

            catch (Exception ex)
            {
                return new ApiResponse<List<RideDetails>>() {
                    IsSuccess = false,
                    Message= ex.Message
                };
            }

        }

        public object AddRide(RideDetails rideDetails)
        {
            try
            {

                var sourceId = _context.Location.Where(x => x.Name == rideDetails.Source).Select(x => x.Id).FirstOrDefault();
                var destinationId = _context.Location.Where(x => x.Name == rideDetails.Destination).Select(x => x.Id).FirstOrDefault();
              
                    _context.Ride.Add(new Ride()
                    {
                        UserId = rideDetails.UserId,
                        SourceId = sourceId,
                        DestinationId = destinationId,
                        Date = rideDetails.Date,
                        Time = rideDetails.Time,
                        IsBooked = false,
                        Distance =Math.Abs(destinationId - sourceId) * 2
                    });;
                    _context.SaveChanges();

                    return new {message ="Ride added" };

            }

            catch (Exception ex)
            {
                return new RideDetails();
            }
            
        }

        

        //public IEnumerable<RideResponse> GetAvailableRides(RideRequest rideRequest)
        //{
        //    try
        //    {
        //        List<RideResponse> rides = new();
        //        var response = _context.Ride1.Where(f => f.Date == rideRequest.Date
        //                                                && f.Time == rideRequest.Time
        //                                                && f.IsBooked == false
        //                                                && f.SeatAvailable>0).ToList();
        //        foreach (var res in response)
        //        {
        //            string[] x = res.Stops?.Split(',');
        //            if ((res.Source == rideRequest.Source && res.Destination == rideRequest.Destination) ||
        //                (res.Source == rideRequest.Source && x != null && x.Contains(rideRequest.Destination)) ||
        //                (x != null && x.Contains(rideRequest.Source) && res.Destination == rideRequest.Destination)
        //                )
        //            {
        //                rides.Add(new RideResponse()
        //                {
        //                    RideId = res.RideId,
        //                    Source = res.Source,
        //                    Destination = res.Destination,
        //                    Date = res.Date,
        //                    Time = res.Time,
        //                    Price= res.Price,
        //                    SeatAvailable= res.SeatAvailable,
        //                    Name = _context.User.Where(f => f.UserId == res.UserId).Select(u => u.Name).FirstOrDefault()
        //                });
        //            }
        //            int index1 = Array.IndexOf(x, rideRequest.Source);
        //            int index2 = Array.IndexOf(x, rideRequest.Destination);
        //            if (x != null && index1 >= 0 && index2 >= 0 && index1 < index2)
        //            {
        //                rides.Add(new RideResponse()
        //                {
        //                    RideId = res.RideId,
        //                    Source = res.Source,
        //                    Destination = res.Destination,
        //                    Date = res.Date,
        //                    Time = res.Time,
        //                    Price = res.Price,
        //                    SeatAvailable= res.SeatAvailable,
        //                    Name = _context.User.Where(f => f.UserId == res.UserId).Select(u => u.Name).FirstOrDefault()
        //                });
        //            }

        //        }
        //        return rides;
        //    }

        //    catch(Exception ex)
        //    {
        //        return new  List<RideResponse>();
        //    }
            

        //}

        public ApiResponse<List<RideResponse>> GetAvailableRides(RideRequest rideRequest,int pricePerKm)
        {
            try
            {
                var result = new ApiResponse<List<RideResponse>>();
                List<RideResponse> rides = new();
                int sourceId = _context.Location.Where(f => f.Name == rideRequest.Source).Select(u=>u.Id).FirstOrDefault();
                int destinationId = _context.Location.Where(f => f.Name == rideRequest.Destination).Select(u => u.Id).FirstOrDefault();
                var res = (from u in _context.User 
                           join v in _context.Vehicle
                           on u.UserId equals v.UserId
                           join r in _context.Ride 
                           on v.UserId equals r.UserId
                           select new
                           {
                               UserId= u.UserId,
                               Name = u.Name,
                               Seats = v.Seats,
                               RideId = r.RideId,
                               Date = r.Date,
                               Time = r.Time,
                               DestinationId=r.DestinationId,
                               sourceId=r.SourceId,
                               IsBooked = r.IsBooked,
                               Distance = r.Distance

                           }).ToList();
                var rideResponse = res.Where(f =>f.sourceId==sourceId && f.DestinationId == destinationId 
                                && f.Date == rideRequest.Date && f.Time == rideRequest.Time && f.IsBooked ==false).ToList();

                foreach(var r in rideResponse)
                {
                    rides.Add(new RideResponse()
                    {
                        Name = r.Name,
                        RideId= r.RideId,
                        Price=  r.Distance*pricePerKm,
                        Source = rideRequest.Source,
                        Destination = rideRequest.Destination,
                        SeatAvailable = r.Seats,
                        Date = r.Date,
                        Time = r.Time,
                    });
                }
                result.Data = rides;
                result.IsSuccess =true;
                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<RideResponse>>()
                {
                    IsSuccess= false,
                    Message= ex.Message
                };
            }
        }

        //public string UpdateRide(RideDetails rideDetails)
        //{
        //    try
        //    {
        //        var update = _context.Ride.Where(f => f.RideId == rideDetails.RideId).FirstOrDefault();
        //        if (update != null)
        //        {
        //            update.SourceId = rideDetails.SourceId;
        //            update.DestinationId = rideDetails.DestinationId;
        //            update.Date = rideDetails.Date;
        //            update.Time = rideDetails.Time;
        //            update.IsBooked = rideDetails.IsBooked;
        //            update.Distance = rideDetails.Distance;
        //            _context.SaveChanges();
        //            return "offer updated";
        //        }
        //        else
        //        {
        //            return "No ride to update";
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        public ApiResponse<List<RideResponse>> GetRides(int userId)
        {
            try
            {
                var apiResponse = new ApiResponse<List<RideResponse>>();
                var res = new List<RideResponse>();
                //return  _mapper.Map<List<RideDetails>>(_context.Ride.Where(_ => _.UserId == userId).ToList());
                var ridesWithId =_context.Ride.Where(_ => _.UserId == userId).ToList();
                foreach(var rides in ridesWithId)
                {
                    res.Add(new RideResponse()
                    {
                        Name = _context.User.Where(_ => _.UserId==rides.UserId)?.Select(x => x.Name).FirstOrDefault(),
                        RideId=rides.RideId,
                        Source = _context.Location.Where(s => s.Id == rides.SourceId)?.Select(x => x.Name).FirstOrDefault(),
                        Destination = _context.Location.Where(s => s.Id == rides.DestinationId)?.Select(x => x.Name).FirstOrDefault(),
                        Date = rides.Date,
                        Time = rides.Time,
                        Price = rides.Distance,
                        SeatAvailable = _context.Vehicle.Where(s => s.UserId== userId).Select(x => x.Seats).FirstOrDefault(),
                    });
                }
                apiResponse.Data = res;
                apiResponse.IsSuccess= true;

                return apiResponse;
            }

            catch (Exception ex)
            {
                return new ApiResponse<List<RideResponse>>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public ApiResponse<List<Locations>> GetLocations()
        {
            try
            {
                var result = new ApiResponse<List<Locations>>();
                var location = _context.Location.ToList();
                if (location != null)
                {
                    result.Data = _mapper.Map<List<Locations>>(location);
                    result.IsSuccess = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Locations>>()
                {
                    IsSuccess= false,
                    Message= ex.Message
                };
            }
        }

        //public string UpdateOfferPartial(int offerId, JsonPatchDocument offerDetails)
        //{
        //    try
        //    {
        //        var update = _context.Offer.Where(f => f.OfferId == offerId).FirstOrDefault();
        //        offerDetails.ApplyTo(_mapper.Map<UpdateOffer>(update));
        //        _context.SaveChanges();
        //        return "offer updated";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}
