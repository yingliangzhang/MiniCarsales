using MiniCarsales.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniCarsales.Repositories
{
    public class CarRepository : VehicleRepository<Car>
    {
        public CarRepository(VehiclesContext vehiclesContext) : base(vehiclesContext)
        {

        }
    }
}
