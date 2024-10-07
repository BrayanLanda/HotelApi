using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelApi.Controllers.BookingsController
{
    public class Delete : BookingsControllerBase
    {
        public Delete(IBookingRepository bookingRepository) : base(bookingRepository)
        {
        }

        [HttpDelete]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("bookings")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingRepository.DeleteBookingAsync(id);
            return NoContent();
        }
    }
}
