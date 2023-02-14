using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Data.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; } 

        public int Seats { get; set; }

    }
}
