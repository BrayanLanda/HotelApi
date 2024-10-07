using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.DTOs
{
    public class GuestDto
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(255, ErrorMessage = "First name cannot exceed 255 characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(255, ErrorMessage = "Last name cannot exceed 255 characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Identification number is required.")]
    [StringLength(20, ErrorMessage = "Identification number cannot exceed 20 characters.")]
    public string IdentificationNumber { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
    public string PhoneNumber { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Birthdate { get; set; }
}
}