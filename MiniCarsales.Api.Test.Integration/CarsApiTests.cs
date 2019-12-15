using Microsoft.Extensions.DependencyInjection;
using MiniCarsales.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using MiniCarsales.Dtos;
using System.Collections.Generic;
using MiniCarsales.Models.Constants;

namespace MiniCarsales.Api.Test.Integration
{
    public class CarsApiTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public CarsApiTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();

            using (var scope = factory.Server.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var vehiclesContext = scopedServices.GetRequiredService<VehiclesContext>();
                
                // Ensure the database is created.
                vehiclesContext.Database.EnsureCreated();
                Utilities.ReinitializeDbForTests(vehiclesContext);
            }

        }

        [Fact]
        public async Task GetAllCarsReturnsCarsDtoResponse()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("/api/cars");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var carsDto = JsonSerializer.Deserialize<List<CarDto>>(responseAsString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            Assert.Equal(3, carsDto.Count);
            Assert.Contains(carsDto, c => c.Id.ToString() == "e7341f86-28bd-49bc-9509-e23752cfa450");
            Assert.Contains(carsDto, c => c.Id.ToString() == "b27f84a0-6ddb-44e6-8f31-123eca58ecbe");
            Assert.Contains(carsDto, c => c.Id.ToString() == "fdaac995-ea18-41ff-8f16-a200d6ec7a40");
        }

        [Fact]
        public async Task CreateCarReturnsCarDtoResponse()
        {
            // Arrange
            var car = new Car
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
            using (var request = new HttpRequestMessage(HttpMethod.Post, "/api/cars"))
            {
                string payload = JsonSerializer.Serialize(car);
                request.Content = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");

                var response = await _client.SendAsync(request);

                // Assert
                response.EnsureSuccessStatusCode();
                var responseAsString = await response.Content.ReadAsStringAsync();
                var carsDto = JsonSerializer.Deserialize<CarDto>(responseAsString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                Assert.Equal(car.Id, carsDto.Id);
                Assert.Equal(car.Model, carsDto.Model);
            }
        }
    }
}
