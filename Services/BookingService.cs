using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Data;
using HotelApi.Errors.General;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Services
{
    public class BookingService : IBookingRepository
    {
        private readonly DataContext _context;

        public BookingService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> SearchBookingsByIdentificationAsync(string identificationNumber)
        {
            return await _context.Bookings
                .Where(b => b.Guest.IdentificationNumber == identificationNumber)
                .ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                throw new IdNotFoundException("Booking", id);
            }
            return booking;
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                throw new IdNotFoundException("Booking", id);
            }
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}