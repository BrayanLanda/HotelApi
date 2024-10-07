using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data
{
    public class DataContext : DbContext
    {
        // Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // DbSets for the entities
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}