using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Data;
using HotelApi.DTOs;
using HotelApi.Errors.General;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Services
{
    public class GuestService : IGuestRepository
    {
        private readonly DataContext _context;

        public GuestService(DataContext context)
        {
            _context = context;
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                throw new IdNotFoundException("Guest", id);
            }
            return guest;
        }

        public async Task DeleteGuestAsync(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                throw new IdNotFoundException("Guest", id);
            }
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Guest>> SearchGuestsAsync(string keyword)
        {
            return await _context.Guests
                .Where(g => g.LastName.Contains(keyword) || g.IdentificationNumber.Contains(keyword))
                .ToListAsync();
        }

        public async Task<Guest> UpdateGuestAsync(int id, GuestUpdateDto guestUpdateDto)
        {
            var existingGuest = await _context.Guests.FindAsync(id);
            if (existingGuest == null)
            {
                throw new IdNotFoundException("Guest", id);
            }

            // Actualizar solo los campos necesarios
            existingGuest.FirstName = guestUpdateDto.FirstName;
            existingGuest.LastName = guestUpdateDto.LastName;
            existingGuest.PhoneNumber = guestUpdateDto.PhoneNumber;

             _context.Guests.Update(existingGuest);
            await _context.SaveChangesAsync();
            return existingGuest;
        }
    }
}