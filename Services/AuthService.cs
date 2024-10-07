using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.DTOs;
using HotelApi.Errors.General;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.AspNetCore.Identity;

namespace HotelApi.Services
{
    public class AuthService : IAuthRepository
    {

        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IPasswordHasher<Employee> _passwordHasher;

        public AuthService(
            IUserRepository userRepository,
            ITokenRepository tokenRepository,
            IPasswordHasher<Employee> passwordHasher)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
            _passwordHasher = passwordHasher;
        }


        public async Task<UserAuthResponseDto> RegisterAsync(EmployeeDto userRegisterDto)
        {
            // User Already Exists
            var existingUser = await _userRepository.GetUserByEmailAsync(userRegisterDto.Email);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException("User", userRegisterDto.Email);
            }

            // Add new User/Employee from EmployeeDto a Employee
            var newEmployee = new Employee
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Email = userRegisterDto.Email,
                IdentificationNumber = userRegisterDto.IdentificationNumber,
                // Hasheamos la contraseña
                Password = _passwordHasher.HashPassword(null, userRegisterDto.Password),
                // Mapea el role desde el string a la enumeración Role
                Role = Enum.Parse<UserRole>(userRegisterDto.Role, true)
            };

            // Guardar usuario en la base de datos a través del UserRepository
            await _userRepository.AddUserAsync(newEmployee);

            // Generar token
            var token = _tokenRepository.CreateToken(newEmployee);

            // Crear y devolver respuesta
            return new UserAuthResponseDto
            {
                Username = newEmployee.FirstName,  // Usar el FirstName como nombre de usuario
                Token = token,
                Role = newEmployee.Role.ToString()
            };
        }

        public async Task<UserAuthResponseDto> LoginAsync(UserLoginDto userLoginDto)
        {
            // Buscar usuario por email
            var employee = await _userRepository.GetUserByEmailAsync(userLoginDto.Email);
            if (employee == null)
            {
                throw new InvalidCredentialsException();
            }

            // Verificar contraseña
            var result = _passwordHasher.VerifyHashedPassword(employee, employee.Password, userLoginDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new InvalidCredentialsException();
            }

            // Generar token
            var token = _tokenRepository.CreateToken(employee);

            // Crear y devolver respuesta
            return new UserAuthResponseDto
            {
                Username = employee.FirstName,
                Token = token,
                Role = employee.Role.ToString()
            };
        }
    }
}