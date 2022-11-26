using ECommerce.API.Customers.Db;
using ECommerce.API.Customers.Interfaces;
using ECommerce.API.Customers.Providers;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CustomersDbContext>(options =>
{
    options.UseInMemoryDatabase("Customers");
});
builder.Services.AddScoped<ICustomersProvider, CustomersProvider>();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
