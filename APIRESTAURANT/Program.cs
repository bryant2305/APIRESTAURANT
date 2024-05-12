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
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IGenericRepository<Ingredient>, IngredientRepository>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<IGenericRepository<Dish>, DishRepository>();
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IDishIngredientsRepository, DishIngredientRepository>();
builder.Services.AddScoped<IGenericRepository<DishIngredients>, DishIngredientRepository>();
builder.Services.AddScoped<IDishIngredientService, DishIngredientService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IGenericRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDishService, OrderDishService>();
builder.Services.AddScoped<IGenericRepository<OrderDish>, OrderDishRepository>();
builder.Services.AddScoped<IOrderDishService, OrderDishService>();
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
