using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers.RoomTypeController
{
    [ApiController]
    [Route("api/v1/room_types")]
    public class RoomTypeControllerBase : ControllerBase
    {
        protected readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeControllerBase(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
    }
}