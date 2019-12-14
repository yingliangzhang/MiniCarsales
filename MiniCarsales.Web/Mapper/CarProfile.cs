using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MiniCarsales.Models;
using MiniCarsales.Dtos;

namespace MiniCarsales.Web.Mapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>();
        }
    }
}
