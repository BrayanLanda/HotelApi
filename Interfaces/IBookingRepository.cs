using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Models;

namespace HotelApi.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> SearchBookingsByIdentificationAsync(string identificationNumber);
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> CreateBookingAsync(Booking booking);
        Task DeleteBookingAsync(int id);
    }
}