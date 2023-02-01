using Carpool.Models;
using Carpool.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services
{
    public class UserService:IUserService
    {

        public UserMapping GetUsers()
        {
            using (StreamReader r = new StreamReader("C://Users//mahfooz.a//source//repos//Carpool//Carpool.Data//UserData.json"))
            {
                string json = r.ReadToEnd();

                UserMapping item = JsonConvert.DeserializeObject<UserMapping>(json);
                return item;
            }
        }
    }
}
