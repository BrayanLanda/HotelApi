using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelApi.Controllers.RoomController
{
    public class RoomController : RoomControllerBase
    {
        public RoomController(IRoomRepository roomRepository) : base(roomRepository)
        {
        }

        [HttpGet("available")]
        [SwaggerOperation(
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("rooms")]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var rooms = await _roomRepository.GetAvailableRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("status")]
        [SwaggerOperation(
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("rooms")]
        public async Task<IActionResult> GetRoomStatus()
        {
            var status = await _roomRepository.GetRoomStatusAsync();
            return Ok(status);
        }
    }
}