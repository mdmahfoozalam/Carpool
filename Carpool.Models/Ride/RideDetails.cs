﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Models.Ride
{
    public class RideDetails
    {
        public int? RideId { get; set; }

        public int UserId { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public DateTime Date { get; set; }

        public string? Time { get; set; }

    }
}
