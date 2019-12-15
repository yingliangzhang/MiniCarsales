using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCarsales.Services;
using AutoMapper;
using MiniCarsales.Models;
using MiniCarsales.Models.Constants;
using MiniCarsales.Dtos;
using Microsoft.Extensions.Logging;

namespace MiniCarsales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IVehicleService<Car> _carService;
        private readonly IMapper _mapper;
        private readonly ILogger<CarsController> _logger;

        public CarsController(IVehicleService<Car> carService, IMapper mapper, ILogger<CarsController> logger)
        {
            _carService = carService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var cars = await _carService.GetAllAsync();
            var carsDto = _mapper.Map<List<Car>, List<CarDto>>(cars);
            _logger.LogInformation("Fetched all cars. Found {Count}", cars.Count);
            return Ok(carsDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Car car)
        {
            var createdCar = await _carService.CreateAysnc(car);
            var carDto = _mapper.Map<Car, CarDto>(createdCar);
            _logger.LogInformation("Created new car with {Id}", createdCar.Id);
            return Ok(carDto);
        }
  
        [HttpGet]
        [Route("body-types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetBodyTypes()
        {
            return Ok(CarBodyType.ToArray());
        }
    }
}