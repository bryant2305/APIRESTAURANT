using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.Mappings;
using ApiRestaurant.Core.Application.Services;
using ApiRestaurant.Core.Domain.Entity;
using ApiRestaurant.Infrastucture.Persistence.Context;
using ApiRestaurant.Infrastucture.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<RestaurantContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
});

builder.Services.AddAutoMapper(typeof(GeneralProfile));
builder.Services.AddScoped<IMesasRepository, MesasRepository>();
builder.Services.AddScoped<IGenericRepository<Mesas>, MesasRepository>(); // Registro de IGenericRepository<Mesas>
builder.Services.AddScoped<IMesasService, MesasService>();

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
