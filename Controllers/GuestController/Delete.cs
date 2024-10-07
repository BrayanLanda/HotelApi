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
        Summary = "Delete a guest",
        Description = "Deletes a guest from the database by their ID. Requires ADMIN role."
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("guests")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            await _guestRepository.DeleteGuestAsync(id);
            return NoContent();
        }
    }
}