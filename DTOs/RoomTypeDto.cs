using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.DTOs
{
    public class RoomTypeDto
    {
        [Required(ErrorMessage = "Room type name is required.")]
        [StringLength(50, ErrorMessage = "Room type name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string Description { get; set; }
    }
}