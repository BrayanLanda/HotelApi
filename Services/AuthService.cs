using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.DTOs;
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
            // Verificar si el usuario ya existe
            var existingUser = await _userRepository.GetUserByEmailAsync(userRegisterDto.Email);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException("User", userRegisterDto.Email);
            }

            // Crear nuevo usuario
            

            // Mapea el role desde el string a la enumeración Role
            newUser.Role = Enum.Parse<UserRole>(userRegisterDto.Role, true);

            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, userRegisterDto.Password);

            // Guardar usuario en la base de datos
            

            // Generar token
            var token = _tokenRepository.CreateToken(newUser);

            // Crear y devolver respuesta
            return new UserAuthResponseDto
            {
                Username = newUser.Username,
                Token = token,
                Role = newUser.Role.ToString()
            };
        }

        public async Task<UserAuthResponseDto> LoginAsync(UserLoginDto userLoginDto)
        {
            // Buscar usuario por email
            var user = await _userRepository.GetUserByEmailAsync(userLoginDto.Email);
            if (user == null)
            {
                throw new InvalidCredentialsException();
            }

            // Verificar contraseña
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userLoginDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new InvalidCredentialsException();
            }

            // Generar token
            var token = _tokenRepository.CreateToken(user);

            // Crear y devolver respuesta
            return new UserAuthResponseDto
            {
                Username = user.FirstName,
                Token = token,
                Role = user.Role.ToString()
            };
        }
    }
}