using Carpool.Models.User;
using Carpool.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Carpool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpGet("getUser")]
        [Authorize]
        public UserViewModel GetUser()
        {
            var currentUser = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Email).Value;
            return _userService.GetUser(currentUser);
        }
    }
}
