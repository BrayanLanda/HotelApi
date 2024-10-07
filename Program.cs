using DotNetEnv;
using HotelApi.Extensions;
using HotelApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//Loading environment variables from the .env file
Env.Load();

// Add services to the container.
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddSwaggerServices(); // Agrega Swagger

//builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Add custom exception handling middleware.
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseSwaggerServices(); // Configura Swagger

app.MapControllers();

app.Run();
