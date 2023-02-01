using Carpool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interfaces
{
    public interface IBookService
    {
        public List<Offers> GetAvailableRide(string from, string to);

        //public void BookAvailableRide();
    }
}
