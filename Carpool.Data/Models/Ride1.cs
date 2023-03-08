using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Data.Models
{
    public class Ride1
    {
        [Key]
        public int RideId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Location")]
        public int SourceId { get; set; }

        [ForeignKey("Location")]
        public int DestinationId { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public bool IsBooked { get; set; }

        public int Distance { get; set; }
    }
}
