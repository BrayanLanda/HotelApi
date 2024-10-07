using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Data;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Services
{
    public class UserService : IUserRepository
    {
         private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }

    public async Task<Employee> GetUserByEmailAsync(string email)
    {
        return await _context.Employees.SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddUserAsync(Employee user)
    {
        _context.Employees.Add(user);  // Agregar el nuevo usuario a la DbSet Employees
        await _context.SaveChangesAsync();  // Guardar cambios en la base de datos
    }
    }
}