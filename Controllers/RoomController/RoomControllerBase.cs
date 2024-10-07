using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers.RoomController
{
    [ApiController]
    [Route("api/v1/rooms")]
    public class RoomControllerBase : ControllerBase
    {
        protected readonly IRoomRepository _roomRepository;

        public RoomControllerBase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
    }
}