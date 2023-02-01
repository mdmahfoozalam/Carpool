using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interfaces
{
    internal interface IBookService
    {
        public void GetAvailableRide();
        public void BookAvailableRide();
    }
}
