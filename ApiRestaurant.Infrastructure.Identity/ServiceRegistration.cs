using ApiRestaurant.Core.Application.DTOS.Account;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Domain.Settings;
using ApiRestaurant.Infrastructure.Identity.Context;
using ApiRestaurant.Infrastructure.Identity.Entities;
using ApiRestaurant.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

public static class ServiceRegistration
{
    public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration config)
    {
        #region Identity
        services.Configure<JWTSettings>(config.GetSection("JWTSettings"));
        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

        //services.ConfigureApplicationCookie(options =>
        //{
        //    options.LoginPath = "/User";
        //    options.AccessDeniedPath = "/User/AccessDenied";
        //});


        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.RequireHttpsMetadata = false;
            opt.SaveToken = false;
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = config["JWTSettings:Issuer"],
                ValidAudience = config["JWTSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTSettings:Key"])),
            };
            opt.Events = new JwtBearerEvents()
            {
                OnAuthenticationFailed = c =>
                {
                    c.NoResult();
                    c.Response.StatusCode = 500;
                    c.Response.ContentType = "text/plain";
                    return c.Response.WriteAsync(c.Exception.ToString());
                },
                OnChallenge = c =>
                {
                    c.HandleResponse();
                    c.Response.StatusCode = 401;
                    c.Response.ContentType = "application/json";
                    var result = JsonConvert.SerializeObject(new jwtResponse() { HasError = true, Error = "No estas autorizado" });
                    return c.Response.WriteAsync(result);
                },
                OnForbidden = c =>
                {
                    c.Response.StatusCode = 403;
                    c.Response.ContentType = "application/json";
                    var result = JsonConvert.SerializeObject(new jwtResponse() { HasError = true, Error = "No estas autorizado para acceder a esta area" });
                    return c.Response.WriteAsync(result);
                }
            };
        });
        #endregion

        #region Database
        if (config.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<IdentityContext>(options =>
                   options.UseInMemoryDatabase("IdentityDb"));
        }
        else
        {
            services.AddDbContext<IdentityContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(
                    config.GetConnectionString("IdentityConnection"),
                    m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)
                );
            });
        }
        #endregion

        #region Services
        services.AddTransient<IAccountService, AccountService>();
        //services.AddTransient<IRoleService, RoleService>();
        #endregion
    }
}

