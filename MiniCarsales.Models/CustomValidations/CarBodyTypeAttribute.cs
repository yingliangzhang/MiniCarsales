using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MiniCarsales.Models.Constants;

namespace MiniCarsales.Models.CustomValidations
{
    public class CarBodyTypeAttribute
    {
        public sealed class ValidCarBodyType : ValidationAttribute
        {
            protected override ValidationResult IsValid(object bodyType, ValidationContext validationContext)
            {
                if (CarBodyType.ToArray().Contains(bodyType))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Invalid car body type");
                }
            }
        }
    }
}
