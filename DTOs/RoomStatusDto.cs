using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.DTOs
{
    public class RoomStatusDto
    {
        public int TotalRooms { get; set; }
        public int AvailableRooms { get; set; }
        public int OccupiedRooms { get; set; }
    }
}