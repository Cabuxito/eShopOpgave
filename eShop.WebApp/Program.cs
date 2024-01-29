using eShop.DataLayer;
using eShop.ServiceLayer.CustomerServices;
using eShop.ServiceLayer.OrderServices;
using eShop.ServiceLayer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var configuration = builder.Configuration;

builder.Services.AddDbContext<eShopContext>(options => options
.UseSqlServer(configuration.GetConnectionString("SQLConnectionString")));

    builder.Services
.AddScoped<IProductServices, ProductServices>()
.AddScoped<IOrderServices, OrderServices>()
.AddScoped<ICustomerServices, CustomerServices>()
.AddSession(option => { option.IdleTimeout = TimeSpan.FromMinutes(30); })
.AddMemoryCache()
.AddMvc();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();