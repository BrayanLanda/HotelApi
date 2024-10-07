using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.DTOs;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelApi.Controllers.EmployeeController
{
    public class AuthController : AuthControllerBase
    {
        public AuthController(IAuthRepository authRepository) : base(authRepository)
        {
        }

        [HttpPost("register")]
        [SwaggerOperation(
        Summary = "Register a new employee",
        Description = "Registers a new employee by providing the necessary details. Returns the created employee information."
        )]
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
        [SwaggerOperation(
        Summary = "Login an existing user",
        Description = "Authenticates a user by verifying the provided credentials."
        )]
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