using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Infrastucture.Persistence.Context;
using ApiRestaurant.Infrastucture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Infrastucture.Persistence
{
    public static class ServiceRegistation
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<RestaurantContext>(options =>
                        options.UseInMemoryDatabase("Restaurante"));
            }
            else
            {
                services.AddDbContext<RestaurantContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), m =>
                            m.MigrationsAssembly(typeof(RestaurantContext).Assembly.FullName)));
            }

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IMesasRepository, MesasRepository>();

        }
    }
}
