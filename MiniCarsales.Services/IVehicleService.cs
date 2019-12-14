using System;
using MiniCarsales.Models;
using MiniCarsales.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MiniCarsales.Services
{
    public interface IVehicleService<TEntity> where TEntity : IEntity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> CreateAysnc(TEntity entity);
    }
}
