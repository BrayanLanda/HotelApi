using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Models;

namespace HotelApi.Interfaces
{
    public interface ITokenRepository
    {
        string CreateToken(Employee employee);
    }
}