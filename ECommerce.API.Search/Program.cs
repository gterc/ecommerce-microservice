using ECommerce.API.Search.Interfaces;
using ECommerce.API.Search.Services;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ISearchService, SearchService>();

builder.Services.AddHttpClient("OrdersService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Orders"]);
});
builder.Services.AddHttpClient("ProductsService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Products"]);
}).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)));
builder.Services.AddHttpClient("CustomersService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Customers"]);
}).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)));
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<ICustomersService, CustomersService>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
