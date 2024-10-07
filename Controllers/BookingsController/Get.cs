using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelApi.Controllers.BookingsController
{
    public class Get : BookingsControllerBase
    {
        public Get(IBookingRepository bookingRepository) : base(bookingRepository)
        {
        }

        [HttpGet("search/{identificationNumber}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("bookings")]
        public async Task<IActionResult> SearchBookings(string identificationNumber)
        {
            var bookings = await _bookingRepository.SearchBookingsByIdentificationAsync(identificationNumber);
            return Ok(bookings);
        }

        [HttpGet("{id}", Name = "GetBookingById")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("bookings")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var bookings = await _bookingRepository.GetBookingByIdAsync(id);
            return Ok(bookings);
        }
    }
}