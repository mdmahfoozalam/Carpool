using Carpool.Data.Models;
using Carpool.Models.Book;
using Carpool.Models.Common;
using Carpool.Models.Ride;
using Carpool.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController 
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService) {
            _bookService = bookService;
        }

        [HttpGet("bookRide")]
        public ApiResponse<string> BookRide(int rideId, int userId)
        {
           return _bookService.BookRide(rideId, userId);
        }

        [HttpGet("getBookedRide")]
        public ApiResponse<List<Bookings>> GetBookedRide(int userId)
        {
            return _bookService.GetBookedRide(userId);
        }

    }
}
