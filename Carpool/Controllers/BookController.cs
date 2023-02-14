using Carpool.Models.Book;
using Carpool.Models.Ride;
using Carpool.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController 
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService) {
            _bookService = bookService;
        }

        [HttpGet("bookRide")]
        public string BookRide(int rideId, int userId)
        {
           return _bookService.BookRide(rideId, userId);
        }

        [HttpGet("getBookedRide")]
        public IEnumerable<BookingDetails> BookedRide(int userId)
        {
            return _bookService.BookedRide(userId);
        }

    }
}
