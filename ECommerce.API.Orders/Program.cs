using ECommerce.API.Orders.Db;
using ECommerce.API.Orders.Interfaces;
using ECommerce.API.Orders.Providers;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<OrdersDbContext>(options =>
{
    options.UseInMemoryDatabase("Orders");
});
builder.Services.AddScoped<IOrdersProvider, OrdersProvider>();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
