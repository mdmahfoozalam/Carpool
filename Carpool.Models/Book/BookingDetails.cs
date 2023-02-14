using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Models.Book
{
    public class BookingDetails
    {
        public int UserId { get; set; }
        public int RideId { get; set; }
        public int SourceId { get; set; }
        public int DestinationId { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
    }
}
