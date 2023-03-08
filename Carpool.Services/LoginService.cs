using Carpool.Data.Models;
using Carpool.Models.User;
using Carpool.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services
{
    public class LoginService : ILoginService
    {
        private readonly CarpoolContext _context;
        private readonly IConfiguration _config;
        public LoginService(CarpoolContext context, IConfiguration config) 
        {
            _context= context;
            _config = config;
        }
        public object Login(string email, string password)
        {
            try
            {
                var mail= _context.User.FirstOrDefault(f => f.Email == email);
                if(mail != null && mail.Password == password)
                {
                    var token = GenerateToken(email);
                    return new
                    {
                        token = token
                    };
                }
                else
                {
                    return new {message = "user does not exist"};
                }
            }

            catch(Exception ex) 
            {
                return ex.Message;
            }
            
        }

        public object SignUp(UserDetails userDetails)
        {
            try
            {
                var mail = _context.User.Where(f=> f.Email == userDetails.Email).FirstOrDefault();
                if (mail == null)
                {
                    _context.User.Add(new User
                    {
                        Name = userDetails.Name,
                        Email = userDetails.Email,
                        Password = userDetails.Password
                    });

                    _context.SaveChanges();
                    return new {message = "Registered Successfully with carpool"};
                }
                else
                {
                    return new { message = "Email Id registered already" };
                }
                
            }
            catch(Exception ex) 
            {
               return ex.Message;
            }
        }

        private string GenerateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credential = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Isuer"],
                audience: _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credential
                );
            return tokenHandler.WriteToken(token);
        }
    }
}
