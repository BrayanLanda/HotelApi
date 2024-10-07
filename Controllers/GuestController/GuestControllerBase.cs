using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers.GuestController
{
    [ApiController]
    [Route("api/v1/guests")]
    public class GuestControllerBase : ControllerBase
    {
        protected readonly IGuestRepository _guestRepository;

        public GuestControllerBase(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }
    }
}