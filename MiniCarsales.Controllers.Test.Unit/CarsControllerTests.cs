using Moq;
using System;
using Xunit;
using MiniCarsales.Models;
using MiniCarsales.Dtos;
using MiniCarsales.Services;
using MiniCarsales.Web.Controllers;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace MiniCarsales.Controllers.Test.Unit
{
    public class CarsControllerTests
    {
        private readonly Mock<IVehicleService<Car>> _carServiceMock;
        private readonly Mapper _mapper;
        private readonly CarsController _carsController;
        private readonly Mock<ILogger<CarsController>> _loggerMock;

        public CarsControllerTests()
        {
            _loggerMock = new Mock<ILogger<CarsController>>();
            _carServiceMock = new Mock<IVehicleService<Car>>();
            _mapper = new Mapper(new MapperConfiguration(config => config.AddMaps(typeof(CarsController).Assembly)));
            _carsController = new CarsController(_carServiceMock.Object, _mapper, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAllReturnsOkResultsContainingListOfCarsWhenServicesReturnsListOfCars()
        {
            // Arrange
            var expected = new List<Car>()
            {
                new Car { Id = Guid.NewGuid(), Type = "Car", Make = "Toyota", Model = "Yaris", NumberOfWheels = 4, NumberOfDoors = 5, Engine = "V4", BodyType = "Sedan" },
                new Car { Id = Guid.NewGuid(), Type = "Car", Make = "Toyota", Model = "RAV4", NumberOfWheels = 4, NumberOfDoors = 5, Engine = "V6", BodyType = "Hatchback" },
                new Car { Id = Guid.NewGuid(), Type = "Truck", Make = "Ford", Model = "Ranger", NumberOfWheels = 4, NumberOfDoors = 4, Engine = "V8", BodyType = "Sedan" }
            };

            _carServiceMock.Setup(c => c.GetAllAsync()).ReturnsAsync(expected);

            // Act
            var result = await _carsController.Get();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var cars = Assert.IsType<List<CarDto>>(okObjectResult.Value);
            Assert.Equal(expected.Count, cars.Count);
            Assert.Contains(cars, c => c.Model == "Yaris");
            Assert.Contains(cars, c => c.Model == "RAV4");
            Assert.Contains(cars, c => c.Model == "Ranger");
        }

        [Fact]
        public async Task CreateReturnsCreatedDtoWhenServicesSuccessfullyCreatesModel()
        {
            // Arrange
            var car = new Car {
                Id = Guid.NewGuid(),
                Type = "Car",
                Make = "Toyota",
                Model = "Yaris",
                NumberOfWheels = 4,
                NumberOfDoors = 5,
                Engine = "V4",
                BodyType = "Sedan"
            };

            var expected = _mapper.Map<Car, CarDto>(car);

            _carServiceMock
                .Setup(c => c.CreateAysnc(It.IsAny<Car>()))
                .ReturnsAsync((Car newCar) => newCar);

            // Act
            var result = await _carsController.Create(car);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var carDto = Assert.IsType<CarDto>(okObjectResult.Value);
            Assert.Equal(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(carDto));
        }
    }
}
