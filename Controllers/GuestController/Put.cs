using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelApi.Controllers.GuestController
{
    public class Put : GuestControllerBase
    {
        public Put(IGuestRepository guestRepository) : base(guestRepository)
        {
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("guests")]
        public async Task<IActionResult> UpdateGuest(int id, [FromBody] Guest guest)
        {
            var updatedGuest = await _guestRepository.UpdateGuestAsync(id, guest);
            return Ok(updatedGuest);
        }
    }
}