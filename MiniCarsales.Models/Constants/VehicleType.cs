using System;
using System.Collections.Generic;
using System.Text;

namespace MiniCarsales.Models.Constants
{
    static class VehicleType
    {
        public const string Car = "Car";
        public const string Boat = "Boat";
        public const string Bike = "Bike";

        public static string[] ToArray()
        {
            return new string[] { Car, Boat, Bike };
        }
    }
}
