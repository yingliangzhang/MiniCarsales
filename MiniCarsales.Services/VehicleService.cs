﻿using MiniCarsales.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MiniCarsales.Repositories;

namespace MiniCarsales.Services
{
    public class VehicleService<TEntity> : IVehicleService<TEntity> where TEntity : Entity
    {
        private readonly IVehicleRepository<TEntity> _vehicleRepository;

        public VehicleService(IVehicleRepository<TEntity> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<TEntity> CreateAysnc(TEntity entity)
        {
            return await _vehicleRepository.CreateAsync(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _vehicleRepository.GetAllAsync();
        }
    }
}
