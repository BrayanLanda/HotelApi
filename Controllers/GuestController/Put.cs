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
        Summary = "Update a guest",
        Description = "Updates the details of an existing guest by their ID. Requires ADMIN role."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("guests")]
        public async Task<IActionResult> UpdateGuest(int id, [FromBody] GuestUpdateDto guestUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedGuest = await _guestRepository.UpdateGuestAsync(id, guestUpdateDto);

            return Ok(updatedGuest);
        }
    }
}