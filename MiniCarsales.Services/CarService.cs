using MiniCarsales.Models;
using MiniCarsales.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniCarsales.Services
{
    public class CarService : VehicleService<Car>
    {
        public CarService(CarRepository carRepository) : base(carRepository)
        {
        }
    }
}
