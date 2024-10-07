using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelApi.Controllers.RoomTypeController
{
    public class RoomTypeController : RoomTypeControllerBase
    {

        public RoomTypeController(IRoomTypeRepository roomTypeRepository) : base(roomTypeRepository)
        {
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("room_types")]
        public async Task<IActionResult> GetRoomTypes()
        {
            var roomTypes = await _roomTypeRepository.GetAllRoomTypesAsync();
            return Ok(roomTypes);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("room_types")]
        public async Task<IActionResult> GetRoomTypeById(int id)
        {
            var roomType = await _roomTypeRepository.GetRoomTypeByIdAsync(id);
            return Ok(roomType);
        }
    }
}