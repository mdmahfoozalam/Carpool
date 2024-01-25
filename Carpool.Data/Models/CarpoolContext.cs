using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Carpool.Data.Models;

public partial class CarpoolContext : DbContext
{
    public CarpoolContext()
    {
    }

    public CarpoolContext(DbContextOptions<CarpoolContext> options)
        : base(options)
    {
    }

 


    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<Vehicle> Vehicle { get; set;  }

    public virtual DbSet<Bookings> Bookings { get; set; }

    public virtual DbSet<Ride> Ride { get; set; } 

    public virtual DbSet<Ride1> Ride1 { get; set; }
    
    public virtual DbSet<Location> Location { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   

      
    }
}
