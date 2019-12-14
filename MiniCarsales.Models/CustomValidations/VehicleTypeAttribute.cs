using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MiniCarsales.Models.Constants;

namespace MiniCarsales.Models.CustomValidations
{
    public class VehicleTypeAttribute
    {
        public sealed class ValidVehicleType : ValidationAttribute
        {
            protected override ValidationResult IsValid(object vehicleType, ValidationContext validationContext)
            {
                if (VehicleType.ToArray().Contains(vehicleType))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Invalid vehicle type");
                }
            }
        }
    }
}
