using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Models
{
    public class Guest
    {
        // Primary key for the Guest table
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string FirstName { get; set; }

        [Required, StringLength(255)]
        public string LastName { get; set; }

        [Required, EmailAddress, StringLength(255)]
        public string Email { get; set; }

        [Required, StringLength(20)]
        public string IdentificationNumber { get; set; }

        [Required, StringLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime? Birthdate { get; set; }

        // Navigation property for the bookings made by the guest
        public List<Booking> Bookings { get; set; }
    }
}