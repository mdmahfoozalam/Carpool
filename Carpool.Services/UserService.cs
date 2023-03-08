using AutoMapper;
using Carpool.Data.Models;
using Carpool.Models.User;
using Carpool.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services
{
    public class UserService : IUserService
    {
        private readonly CarpoolContext _context;
        private readonly IMapper _mapper;

        public UserService(CarpoolContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public UserViewModel GetUser(string email)
        {
            try
            {

                User user = _context.User.Where(x=> x.Email == email).FirstOrDefault();
                return _mapper.Map<UserViewModel>(user);

            }
            catch (Exception ex) 
            { 
                return new UserViewModel();
            }
        }
    }
}
