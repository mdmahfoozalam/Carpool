using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public String Date { get; set; }

        public String Time { get; set; }

        public int Price { get; set; }

        public int Seat { get; set;}
    }
}
