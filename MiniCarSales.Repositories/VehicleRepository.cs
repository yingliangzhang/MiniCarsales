using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniCarsales.Models;

namespace MiniCarsales.Repositories
{
    public class VehicleRepository<TEntity> : IVehicleRepository<TEntity> where TEntity : Entity
    {
        private readonly VehiclesContext _vehicleContext;

        public VehicleRepository(VehiclesContext vehicleContext)
        {
            _vehicleContext = vehicleContext;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _vehicleContext.Set<TEntity>().Add(entity);
            await _vehicleContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _vehicleContext.Set<TEntity>().ToListAsync();
        }
    }
}
