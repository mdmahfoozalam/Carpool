using Carpool.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interfaces
{
    public interface IUserService
    {
        public UserViewModel GetUser(string email);
    }
}
