using ApiRestaurant.Core.Domain.Common;
using ApiRestaurant.Core.Domain.Entity;
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
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Mesas>().HasKey(x => x.ID);

            modelBuilder.Entity<Ingredient>().HasKey(x => x.ID);
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
            #endregion
        }

    }
}
