using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Data.Models
{
    public class Bookings
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RideId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
        public int Price { get; set; }
        public int Seats { get; set; }

    }
}
