using Carpool.Models.Common;
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
        public ApiResponse<string> Login(string email, string password);

        public ApiResponse<string> SignUp(UserDetails userDetails);
    }
}
