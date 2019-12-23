using System;
using MiniCarsales.Models.Constants;
using System.ComponentModel.DataAnnotations;
using static MiniCarsales.Models.CustomValidations.CarBodyTypeAttribute;

namespace MiniCarsales.Models
{
    public class Car : Vehicle
    {
        public Car()
        {
            Type = VehicleType.Car;
        }
        [Required]
        [Range(2, 8)]
        public int NumberOfWheels { get; set; }

        [Required]
        [Range(1, 10)]
        public int NumberOfDoors { get; set; }

        [Required]
        public string Engine { get; set; }

        [Required]
        [MaxLength(10)]
        [ValidCarBodyType]
        public string BodyType { get; set; }
    }
}
