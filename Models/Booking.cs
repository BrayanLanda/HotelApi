using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Models
{
   public class Booking
{
    // Primary key for the Booking table
    [Key]
    public int Id { get; set; }

    // Foreign key for the Guest table
    [ForeignKey("Guest")]
    public int GuestId { get; set; }

    // Foreign key for the Employee table
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Required]
    public double TotalCost { get; set; }

    // Navigation properties
    public Guest Guest { get; set; }
    public Employee Employee { get; set; }
    public List<Room> Rooms { get; set; }
}
}