using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using API.Services;
using System.Reflection;
using API.Mapping;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AppMappingProfile());
});
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICoffeShopService, CoffeShopService>();

var app = builder.Build();

app.MapControllers();

app.Run();
