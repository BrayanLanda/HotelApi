using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Errors.Global;
using HotelApi.Interfaces;
using HotelApi.Services;

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
            // services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            services.AddScoped<ITokenRepository, TokenService>();
            // services.AddScoped<IUserRepository, UserRepository>();
            // services.AddScoped<ICustomerRepository, CustomerRepository>();
            // services.AddScoped<IProductRepository, ProductRepository>();
            // services.AddScoped<ICategoryRepository, CategoryRepository>();
            // services.AddScoped<IAuthRepository, AuthRepository>();
            // services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
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
