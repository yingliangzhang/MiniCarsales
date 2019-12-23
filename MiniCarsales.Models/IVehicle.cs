using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using static MiniCarsales.Models.CustomValidations.VehicleTypeAttribute;

namespace MiniCarsales.Models
{
    public interface IVehicle
    {
        Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        [ValidVehicleType]
        string Type { get; }

        [Required]
        [MaxLength(60)]
        string Make { get; }

        [Required]
        [MaxLength(60)]
        string Model { get; }

        DateTime CreatedAt { get; set; }
        DateTime UpdatedAT { get; set; }
    }
}
