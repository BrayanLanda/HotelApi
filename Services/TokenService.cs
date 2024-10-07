using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace HotelApi.Services
{
    public class TokenService(IConfiguration config) : ITokenRepository
    {
        public string CreateToken(Employee employee)
        {
            var tokenKey = Environment.GetEnvironmentVariable("TOKEN_KEY")
                        ?? throw new Exception("Cannot access tokenKey from appsettings");


            if (tokenKey.Length < 64) throw new Exception("Your tojen needs to be langer");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, employee.FirstName),
                new(ClaimTypes.Role, employee.Role.ToString()),
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}