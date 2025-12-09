using Microsoft.EntityFrameworkCore;
using API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Cross Origin Resource Sharing -- da mozemo da komuniciramo sa localhost 5001 na localhost 4200
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
//ovdje ce biti autentifikacija etc, mora biti PRIJE RUN!!

app.UseCors(x =>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200","http://localhost:4200"));

app.MapControllers();

app.Run();
