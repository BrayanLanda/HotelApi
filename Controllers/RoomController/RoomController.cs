using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        Summary = "Retrieve available rooms",
        Description = "Gets a list of all rooms that are currently          available for booking."
        )]
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
        Summary = "Retrieve room status",
        Description = "Gets the current status (e.g., available, occupied) of all rooms."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("rooms")]
        public async Task<IActionResult> GetRoomStatus()
        {
            var status = await _roomRepository.GetRoomStatusAsync();
            return Ok(status);
        }

        [HttpGet("occupied")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Retrieve occupied rooms",
        Description = "Gets a list of all rooms that are currently  occupied. Requires ADMIN role."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("rooms")]
        public async Task<IActionResult> GetOccupiedRooms()
        {
            var occupiedRooms = await _roomRepository.GetOccupiedRoomsAsync();
            return Ok(occupiedRooms);
        }
    }
}