using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Errors.Global;
using HotelApi.Interfaces;
using HotelApi.Models;
// using HotelApi.Seeders;
using HotelApi.Services;
using Microsoft.AspNetCore.Identity;

namespace HotelApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Configurar el comportamiento del serializador JSON para manejar ciclos de referencia
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                });
            services.AddCors();

            // Registrar los repositorios genéricos
            services.AddScoped<ITokenRepository, TokenService>();
            services.AddScoped<IAuthRepository, AuthService>();
            services.AddScoped<IUserRepository, UserService>();
            // services.AddScoped<IProductRepository, ProductRepository>();
            // services.AddScoped<ICategoryRepository, CategoryRepository>();
            // services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IPasswordHasher<Employee>, PasswordHasher<Employee>>();
            // services.AddScoped<DataSeeder>();
            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Registrar el GlobalExceptionFilter
            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            });

            return services;
        }
    }
}
