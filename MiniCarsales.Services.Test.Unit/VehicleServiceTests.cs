using System;
using Xunit;
using Moq;
using MiniCarsales.Repositories;
using MiniCarsales.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using MiniCarsales.Models.Constants;

namespace MiniCarsales.Services.Test.Unit
{
    public class VehicleServiceTests
    {
        private readonly Mock<IVehicleRepository<Car>> _vehicleRepositoryMock;
        private readonly VehicleService<Car> _vehicleService;

        public VehicleServiceTests()
        {
            _vehicleRepositoryMock = new Mock<IVehicleRepository<Car>>();
            _vehicleService = new VehicleService<Car>(_vehicleRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsyncReturnsCarWhenRepositorySuccessfullyCreatesEntity()
        {
            // Arrange
            _vehicleRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<Car>()))
                .ReturnsAsync((Car car) => car);

            var expected = new Car
            {
                Id = Guid.NewGuid(),
                Type = VehicleType.Car,
                Make = "Toyota",
                Model = "Yaris",
                NumberOfWheels = 4,
                NumberOfDoors = 5,
                Engine = "V4",
                BodyType = CarBodyType.Hatchback
            };

            // Act
            var result = await _vehicleService.CreateAysnc(expected);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetAllAsyncReturnsListOfCarsWhenRepositoryReturnsListOfCars()
        {
            // Arrange
            var expected = new List<Car>()
            {
                new Car { Id = Guid.NewGuid(), Type = VehicleType.Car, Make = "Toyota", Model = "Yaris", NumberOfWheels = 4, NumberOfDoors = 5, Engine = "V4", BodyType = CarBodyType.Sedan },
                new Car { Id = Guid.NewGuid(), Type = VehicleType.Car, Make = "Toyota", Model = "RAV4", NumberOfWheels = 4, NumberOfDoors = 5, Engine = "V6", BodyType = CarBodyType.Hatchback },
                new Car { Id = Guid.NewGuid(), Type = VehicleType.Truck, Make = "Ford", Model = "Ranger", NumberOfWheels = 4, NumberOfDoors = 4, Engine = "V8", BodyType = CarBodyType.Sedan }
            };

            _vehicleRepositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(expected);

            // Act
            var result = await _vehicleService.GetAllAsync();

            // Assert
            Assert.Equal(expected.Count, result.Count);
            Assert.Contains(result, r => r.Model == "Yaris");
            Assert.Contains(result, r => r.Model == "RAV4");
            Assert.Contains(result, r => r.Model == "Ranger");
        }
    }
}
