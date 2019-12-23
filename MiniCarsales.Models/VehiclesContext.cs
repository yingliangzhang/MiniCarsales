using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MiniCarsales.Models
{
    public class VehiclesContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public VehiclesContext(DbContextOptions<VehiclesContext> options) : base(options)
        {
        }

        /// <summary>
        /// Override SaveChangesAsync to auto populate CreatedAt and UpdatedAt on save
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IVehicle && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((IVehicle)entityEntry.Entity).UpdatedAT = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IVehicle)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
