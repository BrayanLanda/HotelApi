using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.DTOs
{
   public class BookingDto
{
    [Required(ErrorMessage = "Guest ID is required.")]
    public int GuestId { get; set; }

    [Required(ErrorMessage = "Employee ID is required.")]
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "Start date is required.")]
    [DataType(DataType.DateTime, ErrorMessage = "Invalid start date format.")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Invalid end date format.")]
    public DateTime? EndDate { get; set; }

    [Required(ErrorMessage = "Total cost is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Total cost must be greater than 0.")]
    public double TotalCost { get; set; }
}
}