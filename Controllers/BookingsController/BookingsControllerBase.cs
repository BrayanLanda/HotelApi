using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers.BookingsController
{
    [ApiController]
    [Route("api/v1/bookings")]
    public class BookingsControllerBase : ControllerBase
    {
        protected readonly IBookingRepository _bookingRepository;

        public BookingsControllerBase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
    }
}