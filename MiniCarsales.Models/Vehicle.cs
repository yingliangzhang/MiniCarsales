using System;
using System.ComponentModel.DataAnnotations;
using static MiniCarsales.Models.CustomValidations.VehicleTypeAttribute;

namespace MiniCarsales.Models
{
    public abstract class Vehicle : Entity, IEntity
    {
        [Required]
        [MaxLength(30)]
        [ValidVehicleType]
        public string Type { get; set; }

        [Required]
        [MaxLength(60)]
        public string Make { get; set; }

        [Required]
        [MaxLength(60)]
        public string Model { get; set; }
    }
}
