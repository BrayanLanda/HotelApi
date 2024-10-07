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
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
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