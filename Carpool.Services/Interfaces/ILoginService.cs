using Carpool.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interfaces
{
    public interface ILoginService
    {
        public object Login(string email, string password);

        public object SignUp(UserDetails userDetails);
    }
}
