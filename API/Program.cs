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

builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
        options.Authority = "https://localhost:5443";
        options.ApiName = "CoffeeAPI";
    });

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICoffeeShopService, CoffeeShopService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
