using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.Services;
using ApiRestaurant.Core.Domain.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application
{
    public static class ServiceRegistration
    {

        public static void AddRestauranteLayer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IMesasService, MesasService>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IDishService, DishService>();
            services.AddTransient<IDishIngredientService, DishIngredientService>();

        }
    }
}
