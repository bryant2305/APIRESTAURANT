using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.Mappings;
using ApiRestaurant.Core.Application.Services;
using ApiRestaurant.Core.Domain.Entity;
using ApiRestaurant.Infrastructure.Identity.Context;
using ApiRestaurant.Infrastructure.Identity.Entities;
using ApiRestaurant.Infrastructure.Identity.Seeds;
using ApiRestaurant.Infrastucture.Persistence.Context;
using ApiRestaurant.Infrastucture.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
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

builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
});


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddAutoMapper(typeof(GeneralProfile));

// Register repositories and services
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
using var scope = app.Services.CreateScope();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
await DefaultRoles.SeedAsync(userManager, roleManager);
await DefaultSuperAdminUser.SeedAsync(userManager, roleManager);
await DefaultAdminUser.SeedAsync(userManager, roleManager);
await DefaultWaiterUser.SeedAsync(userManager, roleManager);

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
