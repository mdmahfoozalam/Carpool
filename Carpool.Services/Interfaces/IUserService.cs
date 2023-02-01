using Carpool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interfaces
{
    internal interface IUserService
    {
        public List<Users> GetUsers();
   
    }
}
