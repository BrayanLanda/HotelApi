using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Models;

namespace HotelApi.Interfaces
{
    public interface IRoomTypeRepository
    {
        Task<IEnumerable<RoomType>> GetAllRoomTypesAsync();
        Task<RoomType> GetRoomTypeByIdAsync(int id);
    }
}