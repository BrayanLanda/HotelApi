using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.DTOs;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelApi.Controllers.BookingsController
{
    public class Post : BookingsControllerBase
    {
        public Post(IBookingRepository bookingRepository) : base(bookingRepository)
        {
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("bookings")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var booking = new Booking
            {
                GuestId = bookingDto.GuestId,
                EmployeeId = bookingDto.EmployeeId,
                StartDate = bookingDto.StartDate,
                EndDate = bookingDto.EndDate,
                TotalCost = bookingDto.TotalCost,
                Rooms = new List<Room> {  } // Asigna la habitación encontrada
            };

            var createdBooking = await _bookingRepository.CreateBookingAsync(booking);
            return CreatedAtRoute(nameof(Get.GetBookingById), new { id = createdBooking.Id }, createdBooking);
        }
    }
}
