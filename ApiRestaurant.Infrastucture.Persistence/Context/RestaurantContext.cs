using ApiRestaurant.Core.Domain.Common;
using ApiRestaurant.Core.Domain.Entity;
using ApiRestaurant.Infrastucture.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Infrastucture.Persistence.Context
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

        public DbSet<Mesas> Mesas { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "System";
                        break;
                    case EntityState.Modified:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "System";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region tables

            modelBuilder.Entity<Mesas>()
                .ToTable("Mesas");

            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");


            modelBuilder.Entity<Dish>().ToTable("Dish");
            #endregion

            

            #region "primary keys"
            modelBuilder.Entity<Mesas>().HasKey(x => x.ID);

            modelBuilder.Entity<Ingredient>().HasKey(x => x.ID);

            modelBuilder.Entity<Dish>().HasKey(x => x.ID);

            modelBuilder.Entity<Order>().HasKey(x => x.ID);


            #endregion

            #region "property config"
            #region "Tables"
            modelBuilder.Entity<Mesas>().Property(medicos => medicos.Nombre).IsRequired();

            modelBuilder.Entity<Mesas>().Property(medicos => medicos.Descripcion).IsRequired();

            modelBuilder.Entity<Mesas>().Property(medicos => medicos.Estado).IsRequired();

            modelBuilder.Entity<Mesas>().Property(medicos => medicos.CantidadPersonas).IsRequired();
            #endregion
            #region Ingredient
            modelBuilder.Entity<Ingredient>().Property(medicos => medicos.Name).IsRequired();
            #endregion

            #region Dish
            modelBuilder.Entity<Dish>().Property(medicos => medicos.Name).IsRequired();

            modelBuilder.Entity<Dish>().Property(medicos => medicos.Price).IsRequired();

            modelBuilder.Entity<Dish>().Property(medicos => medicos.AmountPeople).IsRequired();

            modelBuilder.Entity<Dish>().Property(medicos=>medicos.Category).IsRequired();

            #endregion

            #region
            modelBuilder.Entity<Order>().Property(medicos => medicos.Status).IsRequired();

            modelBuilder.Entity<Order>().Property(medicos => medicos.Subtotal).IsRequired();

            modelBuilder.Entity<Order>().Property(medicos => medicos.DishSelected).IsRequired();

            #endregion
            #endregion

            #region "Relationships"

            modelBuilder.Entity<Ingredient>().HasMany<DishIngredients>(i => i.Ingredients).WithOne(it => it.Ingredient).HasForeignKey(it => it.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dish>().HasMany<DishIngredients>(dish => dish.Ingredients)
                          .WithOne(ingredients => ingredients.Dish).HasForeignKey(ingredients => ingredients.DishId).OnDelete(DeleteBehavior.Cascade);
            #endregion
        }

    }
}
