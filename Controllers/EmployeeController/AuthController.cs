using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.DTOs;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers.EmployeeController
{
    public class AuthController : AuthControllerBase
    {
        public AuthController(IAuthRepository authRepository) : base(authRepository)
        {
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("auth")]
        public async Task<IActionResult> Register(EmployeeDto userRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authRepository.RegisterAsync(userRegisterDto);

            return CreatedAtAction(nameof(Register), new { username = result.Username }, result);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("auth")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authRepository.LoginAsync(userLoginDto);

            return Ok(result);
        }
    }
}