using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Models
{
    public class Employee
    {
        // Primary key for the Employee table
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress, StringLength(255)]
        public string Email { get; set; }

        [Required, StringLength(20)]
        public string IdentificationNumber { get; set; }

        [Required, StringLength(255)]
        public string Password { get; set; }

        // Use enum for role
        public UserRole Role { get; set; }

        // Navigation property for the bookings made by the employee
        public List<Booking> Bookings { get; set; }
    }
}