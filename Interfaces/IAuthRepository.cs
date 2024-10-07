using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.DTOs;

namespace HotelApi.Interfaces
{
    public interface IAuthRepository
    {
        Task<UserAuthResponseDto> RegisterAsync(EmployeeDto userRegisterDto);
        Task<UserAuthResponseDto> LoginAsync(UserLoginDto userLoginDto);
    }
}