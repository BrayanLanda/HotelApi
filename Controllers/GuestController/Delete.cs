using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelApi.Controllers.GuestController
{
    public class Delete : GuestControllerBase
    {
        public Delete(IGuestRepository guestRepository) : base(guestRepository)
        {
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("guests")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            await _guestRepository.DeleteGuestAsync(id);
            return NoContent();
        }
    }
}