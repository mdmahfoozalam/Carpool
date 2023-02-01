using Carpool.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Carpool.Services.Interfaces;

namespace Carpool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService ) 
        {
            _userService = userService;
        }
        [HttpGet]
        public UserMapping Get()
        {
            UserMapping users = _userService.GetUsers();
            return users;
        }
    }
}
