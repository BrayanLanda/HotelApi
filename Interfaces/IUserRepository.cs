using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Models;

namespace HotelApi.Interfaces
{
    public interface IUserRepository
    {
        Task<Employee> GetUserByEmailAsync(string email);
        Task AddUserAsync(Employee user);
    }
}