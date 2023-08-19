using Hangfire;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Task_5;
using Task_5.Services.City;
using Task_5.Services.Employee;
using Task3.Cash;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(c =>
    c.UseSqlServer(connStr));
builder.Services.AddControllers();
//builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();
builder.Services.AddSwaggerGen(); builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddSwaggerGen(); builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICache, MemoryCache>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddHangfire(x => x.UseSqlServerStorage(connStr));
builder.Services.AddHangfireServer();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
