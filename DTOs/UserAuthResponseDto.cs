using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.DTOs
{
    public class UserAuthResponseDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string Role { get; set; } // Example: "ADMIN"
    }
}