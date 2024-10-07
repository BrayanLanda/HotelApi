using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Models
{
    public class Room
    {
        // Primary key for the Room table
        [Key]
        public int Id { get; set; }

        // Foreign key for the RoomType table
        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }

        [Required]
        public decimal PricePerNight { get; set; }

        [Required]
        public bool Availability { get; set; }

        [Required]
        public int MaxOccupancy { get; set; }

        // Navigation property for the room type
        public RoomType RoomType { get; set; }

        // Navigation property for the bookings in this room
        public List<Booking> Bookings { get; set; }
    }
}