using Carpool.Models;
using Carpool.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService) {
            _bookService = bookService;
        }
        [HttpGet]
        public List<Offers> GetOffers(string from, string to)
        {
            List<Offers> offers = _bookService.GetAvailableRide(from , to);
            return offers;
        }
    }
}
