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
    public class Get : GuestControllerBase
    {
        public Get(IGuestRepository guestRepository) : base(guestRepository)
        {
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Retrieve a guest by ID",
        Description = "Gets the details of a guest by their ID. Requires ADMIN role."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("guests")]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var guest = await _guestRepository.GetGuestByIdAsync(id);
            return Ok(guest);
        }

        [HttpGet("search/{keyword}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Search guests",
        Description = "Searches for guests in the database using a keyword. Requires ADMIN role."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("guests")]
        public async Task<IActionResult> SearchGuests(string keyword)
        {
            var guests = await _guestRepository.SearchGuestsAsync(keyword);
            return Ok(guests);
        }
    }
}