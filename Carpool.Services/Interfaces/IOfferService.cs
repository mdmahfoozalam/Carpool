using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interfaces
{
    internal interface IOfferService
    {
        public void AddOfferRide();

        public void RemoveOfferRide();

        public void UpdateOfferRide();
    }
}
