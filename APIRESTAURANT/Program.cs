using ApiRestaurant.Core.Application;
using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.Mappings;
using ApiRestaurant.Core.Application.Services;
using ApiRestaurant.Core.Domain.Entity;
using ApiRestaurant.Core.Domain.Settings;
using ApiRestaurant.Infrastructure.Identity.Context;
using ApiRestaurant.Infrastructure.Identity.Entities;
using ApiRestaurant.Infrastructure.Identity.Seeds;
using ApiRestaurant.Infrastructure.Identity.Services;
using ApiRestaurant.Infrastucture.Persistence;
using ApiRestaurant.Infrastucture.Persistence.Context;
using ApiRestaurant.Infrastucture.Persistence.Repositories;
using APIRESTAURANT.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioningExtension();
builder.Services.AddSwaggerExtension();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressInferBindingSourcesForParameters = true;
    options.SuppressMapClientErrors = false;
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//builder.Services.AddDbContext<RestaurantContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
});


// Register the JWT settings from the configuration
builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddAutoMapper(typeof(GeneralProfile));


//builder.Services.AddIdentityInfraestructure(builder.Configuration);
builder.Services.AddRestauranteLayer(builder.Configuration);
builder.Services.AddPersistenceInfraestructure(builder.Configuration);

builder.Services.AddScoped<IAccountService, AccountService>();

var app = builder.Build();
using var scope = app.Services.CreateScope();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
await DefaultRoles.SeedAsync(userManager, roleManager);
await DefaultSuperAdminUser.SeedAsync(userManager, roleManager);
await DefaultAdminUser.SeedAsync(userManager, roleManager);
await DefaultWaiterUser.SeedAsync(userManager, roleManager);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "RESTAURANT API");
        options.DefaultModelRendering(ModelRendering.Model);
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
