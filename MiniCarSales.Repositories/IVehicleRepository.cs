using MiniCarsales.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniCarsales.Repositories
{
    public interface IVehicleRepository<TEntity> where TEntity : IEntity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
    }
}
