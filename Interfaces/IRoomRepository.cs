using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.DTOs;
using HotelApi.Models;

namespace HotelApi.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAvailableRoomsAsync();
        Task<RoomStatusDto> GetRoomStatusAsync();
    }
}