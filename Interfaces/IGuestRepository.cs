using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.DTOs;
using HotelApi.Models;

namespace HotelApi.Interfaces
{
    public interface IGuestRepository
    {
        Task<Guest> GetGuestByIdAsync(int id);
        Task DeleteGuestAsync(int id);
        Task<IEnumerable<Guest>> SearchGuestsAsync(string keyword);
        Task<Guest> UpdateGuestAsync(int id, GuestUpdateDto guestUpdateDto);
    }
}