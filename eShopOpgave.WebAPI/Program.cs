using eShop.DataLayer;
using eShop.ServiceLayer.CustomerServices;
using eShop.ServiceLayer.OrderServices;
using eShop.ServiceLayer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddDbContext<eShopContext>(options => options
.UseSqlServer(configuration.GetConnectionString("SQLConnectionString")));

builder.Services
.AddScoped<IProductServices, ProductServices>()
.AddScoped<IOrderServices, OrderServices>()
.AddScoped<ICustomerServices, CustomerServices>()
.AddMvc();

var app = builder.Build();
//Under development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
