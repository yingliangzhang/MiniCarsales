using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCarsales.Services;
using AutoMapper;
using MiniCarsales.Models;
using MiniCarsales.Dtos;

namespace MiniCarsales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarService _carService;
        private readonly IMapper _mapper;

        public CarsController(CarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var cars = await _carService.GetAllAsync();
            var carsDto = _mapper.Map<List<Car>, List<CarDto>>(cars);
            return Ok(carsDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Car car)
        {
            var createdCar = await _carService.CreateAysnc(car);
            var carDto = _mapper.Map<Car, CarDto>(createdCar);
            return Ok(carDto);
        }
    }
}