using Carpool.Data.Models;
using Carpool.Services;
using Carpool.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IRideService, RideService>();
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddDbContext<CarpoolContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbconnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
