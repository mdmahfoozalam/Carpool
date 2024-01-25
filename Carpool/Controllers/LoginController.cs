using Carpool.Models.Common;
using Carpool.Models.User;
using Carpool.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("login")]
        public ApiResponse<string> Login(string email, string password) 
        {
            return _loginService.Login(email, password);
        }

        [HttpPost("signUp")]
        public object SignUp(UserDetails userDetails)
        {
            return _loginService.SignUp(userDetails); 
        }
    }

    public class LoginViewModel
    {
        public string AccessToken { get; set; }
        public bool IsSuccess { get; set; }
        
        public string Message { get; set; }
    }
}
