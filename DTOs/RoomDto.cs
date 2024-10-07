using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.DTOs
{
    public class RoomDto
{
    [Required(ErrorMessage = "Room type ID is required.")]
    public int RoomTypeId { get; set; }

    [Required(ErrorMessage = "Price per night is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price per night must be greater than 0.")]
    public decimal PricePerNight { get; set; }

    [Required(ErrorMessage = "Availability status is required.")]
    public bool Availability { get; set; }

    [Required(ErrorMessage = "Maximum occupancy is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Maximum occupancy must be at least 1.")]
    public int MaxOccupancy { get; set; }
}
}