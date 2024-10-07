using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Models
{
    public class RoomType
    {
        // Primary key for the RoomType table
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        // Navigation property for the rooms of this type
        public List<Room> Rooms { get; set; }
    }
}