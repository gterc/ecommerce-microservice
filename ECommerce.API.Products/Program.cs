using ECommerce.API.Products.Db;
using ECommerce.API.Products.Interfaces;
using ECommerce.API.Products.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductsDbContext>(options =>
{
    options.UseInMemoryDatabase("Products");
});
builder.Services.AddScoped<IProductsProvider, ProductsProvider>();
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
