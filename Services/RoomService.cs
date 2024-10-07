using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Data;
using HotelApi.DTOs;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Services
{
    public class RoomService : IRoomRepository
    {
        private readonly DataContext _context;

        public RoomService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync()
        {
            return await _context.Rooms
                .Where(r => r.Availability)
                .ToListAsync();
        }

        public async Task<RoomStatusDto> GetRoomStatusAsync()
        {
            var totalRooms = await _context.Rooms.CountAsync();
            var availableRooms = await _context.Rooms.CountAsync(r => r.Availability);
            var occupiedRooms = totalRooms - availableRooms;

            return new RoomStatusDto
            {
                TotalRooms = totalRooms,
                AvailableRooms = availableRooms,
                OccupiedRooms = occupiedRooms
            };
        }
    }
}